using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public int GameScore;
    public int GameMater;
    [SerializeField] List<Sprite> NumSpriteList;
    public List<GameObject> NumList;
    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log(NumSpriteList.Count);

        for (int i = 0; i < NumList.Count; i++)
        {
            NumList[i].transform.position = new Vector3(11+(0.35f*i), 3, -100);
        }
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

    private void ScoreReview()
    {
        string reviewscore = GameScore.ToString("000000");

        for (int i = 0; i< NumList.Count; i++)
        {
            SpriteRenderer sr;
            sr = NumList[i].GetComponent<SpriteRenderer>();
            //Debug.Log($"er{int.Parse(reviewscore.Substring(i,1))}");
            sr.sprite = NumSpriteList[int.Parse(reviewscore.Substring(i,1))];
        }
        //Debug.Log($"reviewscore={reviewscore}");
    }

    public void ScoreCamera(Vector3 pos)
    {
        for (int i = 0; i < NumList.Count; i++)
        {
            NumList[i].transform.position += pos;
        }
    }
}
