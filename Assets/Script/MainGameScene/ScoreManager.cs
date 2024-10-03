using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static int GameScore=0;
    public int GameMater;
    [SerializeField] List<Sprite> NumSpriteList;
    public List<GameObject> NumList;
    [SerializeField] GameObject SCORE;
    [SerializeField] GameObject STEPS;
    private List<GameObject> UIScrollList;//スクロールさせるUIはここにぶち込む
    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log(NumSpriteList.Count);
        UIScrollList = new List<GameObject>();
        SetStartSprict();
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
        GameMater += 1;
        Debug.Log($"Mater:{GameMater}");
        //ScoreReview();
    }


    private void SetStartSprict()
    {
        //数字
        for (int i = 0; i < NumList.Count; i++)
        {
            NumList[i].transform.position = new Vector3(-0.5f + (0.5f * i), 5, -100);//座標ゼロに移動
            NumList[i].transform.position += new Vector3(11, -1, -100);
            UIScrollList.Add(NumList[i]);
        }
        //SCORE
        SCORE.transform.position = new Vector3(-0.5f, 5, -100);//座標ゼロに移動
        SCORE.transform.position += new Vector3(11, 0, -100);
        UIScrollList.Add(SCORE);
        //STEPS
        STEPS.transform.position = new Vector3(-0.5f, 5, -100);//座標ゼロに移動
        STEPS.transform.position += new Vector3(11, -3, -100);
        UIScrollList.Add(STEPS);
    }

    private void ScoreReview()
    {
        string reviewscore = GameScore.ToString("000000");

        for (int i = 0; i < NumList.Count; i++)
        {
            SpriteRenderer sr;
            sr = NumList[i].GetComponent<SpriteRenderer>();
            //Debug.Log($"er{int.Parse(reviewscore.Substring(i,1))}");
            sr.sprite = NumSpriteList[int.Parse(reviewscore.Substring(i, 1))];
        }
        //Debug.Log($"reviewscore={reviewscore}");
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
