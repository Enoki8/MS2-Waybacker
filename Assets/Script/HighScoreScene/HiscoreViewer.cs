using System.Collections.Generic;
using UnityEngine;

public class HiscoreViewer : MonoBehaviour
{
    public int[] hiscores = new int[5];
    [SerializeField] FontStore fontStore;
    [SerializeField] GameObject Number_0;

    [SerializeField] SmoothDamp SmoothDamp;

    private float _currentVelocity = 0;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("test");
        //testscores
        hiscores[0] = 12346712;
        hiscores[1] = 40000;
        hiscores[2] = 30000;
        hiscores[3] = 20000;
        hiscores[4] = 10000;
        Showscore();
    }

    // Update is called once per frame
    void Update()
    {
        SmoothMove();
    }
    private void Showscore()
    {
        for (int ii = 0; ii < 5; ii++)
        {
            string numberStr = hiscores[ii].ToString();
            print(numberStr);
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
                Vector2 target = new Vector2(4+(-numberStr.Length*0.5f)+(i * 0.5f), (2f - (ii * 1.5f)));
                numloc.target = target;
            }
        }
    }
    private void SmoothMove()
    {

    }
}
