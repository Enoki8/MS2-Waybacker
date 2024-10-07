using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{

    [SerializeField] List<Sprite> NumSpriteList;
    [SerializeField] FollowCamera followcamera;

    [SerializeField] GameObject SCORE;
    public static int GameScore=0;
    public List<GameObject> ScoreNumList;

    public int GameSteps;
    [SerializeField] GameObject Number_0;//0のスクリプト
    [SerializeField] GameObject StepsNumber;//数字の親
    public List<GameObject> StepsNumlist;

    [SerializeField] GameObject STEPS;
    private List<GameObject> UIScrollList;//スクロールさせるUIはここにぶち込む

    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log(NumSpriteList.Count);
        UIScrollList = new List<GameObject>();

        SetStartSprict();
        StepsReview();
    }
    // Update is called once per frame
    //void Update()
    //{

    //}
    public void ScoreUp(int score)
    {
        GameScore += score;
        //Debug.Log($"Score:{GameScore}");
        ScoreReview();
    }
    public void MaterUp()
    {
        GameSteps += 1;
        //Debug.Log($"Mater:{GameSteps}");
        StepsReview();
    }


    private void SetStartSprict()
    {
        //数字
        for (int i = 0; i < ScoreNumList.Count; i++)
        {
            UIScrollList.Add(ScoreNumList[i]);
        }
        UIScrollList.Add(StepsNumlist[0]);
        UIScrollList.Add(SCORE);
        UIScrollList.Add(STEPS);
    }

    private void ScoreReview()
    {
        string reviewscore = GameScore.ToString("000000");

        for (int i = 0; i < ScoreNumList.Count; i++)
        {
            SpriteRenderer sr;
            sr = ScoreNumList[i].GetComponent<SpriteRenderer>();
            //Debug.Log($"er{int.Parse(reviewscore.Substring(i,1))}");
            sr.sprite = NumSpriteList[int.Parse(reviewscore.Substring(i, 1))];
        }
        //Debug.Log($"reviewscore={reviewscore}");
    }

    private void StepsReview()
    {
        string reviewsteps = GameSteps.ToString();
        while (reviewsteps.Length != StepsNumlist.Count)
        {
            GameObject newnum;
            Quaternion q = new Quaternion();
            Vector3 pos = new Vector3(0, 0, 0);
            newnum = Instantiate(Number_0,pos, q);
            Debug.Log($"StepNumlist.Count:{StepsNumlist.Count} GameSteps:{GameSteps}");
            newnum.transform.position += new Vector3(((StepsNumlist.Count) * -0.5f) + 7, StepsNumlist[0].transform.position.y, +100);
            newnum.transform.parent=StepsNumber.transform;
            StepsNumlist.Add(newnum);
            UIScrollList.Add(newnum);
        }

        for (int i = 0; i < StepsNumlist.Count; i++)
        {
            SpriteRenderer sr;
            sr = StepsNumlist[StepsNumlist.Count-i-1].GetComponent<SpriteRenderer>();
            //Debug.Log($"er{int.Parse(reviewscore.Substring(i,1))}");
            sr.sprite = NumSpriteList[int.Parse(reviewsteps.Substring(i, 1))];
        }
    }

    public void UICamera(Vector3 pos)//UI移動用
    {
        //Debug.Log(UIScrollList.Count);
        for (int i = 0; i < UIScrollList.Count; i++)
        {
            UIScrollList[i].transform.position += pos;
        }

    }
}
