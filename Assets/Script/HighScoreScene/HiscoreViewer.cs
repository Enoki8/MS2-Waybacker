using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HiscoreViewer : MonoBehaviour
{
    [SerializeField] FontStore fontStore;
    [SerializeField] GameObject Number_0;
    [SerializeField] GameObject Black;
    [SerializeField] SmoothDamp SmoothDamp;
    [SerializeField] private float transparency;
    private float _currentVelocity = 0;


    // Start is called before the first frame update
    void Start()
    {
        int[] hiscores=StaticNumberStore.ReturnHiscores();
        Showscore(hiscores);
        int[,] hiscorename=StaticNumberStore.ReturnHiscoresName();
        Showscorename(hiscorename);
    }

    private void Update()
    {
            Black.GetComponent<SpriteRenderer>().color -= new Color(0,0,0,transparency);
    }   

    private void Showscore(int[] hiscores)
    {
        for (int ii = 0; ii < 5; ii++)
        {
            string numberStr = hiscores[ii].ToString();
            List<int> digits = new List<int>();
            foreach (char c in numberStr)
            {
                digits.Add(int.Parse(c.ToString()));
            }
            for (int i = numberStr.Length; i>0; i--)
            {
                GameObject newnum;
                Quaternion q = new Quaternion();
                Vector2 pos = new Vector3(-4, (2f - (ii * 1.5f)));
                newnum = Instantiate(Number_0, pos, q);

                SmoothDamp numloc;
                SpriteRenderer sr;

                numloc = newnum.AddComponent<SmoothDamp>();
                sr = newnum.GetComponent<SpriteRenderer>();

                sr.sprite = fontStore.number[digits[i-1]];
                Vector2 target = new Vector2(5.1f+(-numberStr.Length*0.5f)+(i * 0.5f), (2f - (ii * 1.5f)));
                numloc.target = target;
            }
        }
    }
    private void Showscorename(int[,] hiscorename)
    {
        for (int ii = 0; ii < 5; ii++) 
        {
            for(int i = 0; i<3; i++)
            {
                GameObject newalp;
                Quaternion q = new Quaternion();
                Vector2 pos = new Vector3(-4, (2f - (ii * 1.5f)));
                newalp = Instantiate(Number_0, pos, q);

                SmoothDamp alploc;
                SpriteRenderer sr;

                alploc=newalp.AddComponent<SmoothDamp>();
                sr=newalp.GetComponent<SpriteRenderer>();

                sr.sprite=fontStore.fonts[hiscorename[ii,i]];
                Vector2 target= new Vector2(-2+(i * 0.8f), (2f - (ii * 1.5f)));
                alploc.target = target;
            }
        }
    }
}
