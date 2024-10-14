using System.Collections.Generic;
using UnityEngine;

public class HiscoreViewer : MonoBehaviour
{
    public int[] hiscores = new int[5];
    [SerializeField] FontStore fontStore;
    [SerializeField] GameObject Number_0;

    private float _currentVelocity = 0;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("test");
        //testscores
        hiscores[0] = 50000;
        hiscores[1] = 40000;
        hiscores[2] = 30000;
        hiscores[3] = 20000;
        hiscores[4] = 10000;
        Showscore();
    }

    // Update is called once per frame
    void Update()
    {

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
            for (int i = 0; i < 5; i++)
            {
                GameObject newnum;
                Quaternion q = new Quaternion();
                Vector3 pos = new Vector3(0, 0, 0);
                newnum = Instantiate(Number_0, pos, q);
                SpriteRenderer sr;
                sr = newnum.GetComponent<SpriteRenderer>();
                sr.sprite = fontStore.number[digits[i]];
                Vector2 target = new Vector2(i * 0.5f, -ii);
                newnum.transform.position = target;
            }
        }
    }
}
