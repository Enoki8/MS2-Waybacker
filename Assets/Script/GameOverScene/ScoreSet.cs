using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreSet : MonoBehaviour
{
    [SerializeField] List<GameObject> Scores;
    [SerializeField] FontStore fontStore;
    [SerializeField] ViewThankyou ViewThankyou;
    [SerializeField] ViewRankin ViewRankin;
    [SerializeField] GameObject NameEntry;
    // Start is called before the first frame update
    void Start()
    {
        StaticList.ingame = false;

        ScoreSetting();
        ChangeRanking();
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void ScoreSetting()
    {
        string reviewscore = StaticNumberStore.thisgamescore.ToString("000000");
        for (int i = 0; i < Scores.Count; i++)
        {
            SpriteRenderer sr;
            sr = Scores[i].GetComponent<SpriteRenderer>();
            sr.sprite = fontStore.number[int.Parse(reviewscore.Substring(i, 1))];
        }
    }
    private void ChangeRanking()
    {
        int[] hiscores = new int[6];
        for (int i = 0; i < 5; i++)
        {
            hiscores[i] = StaticNumberStore.hiscores[i];
        }
        hiscores[5] = StaticNumberStore.thisgamescore;
        int[] sortscores = hiscores.OrderByDescending(n => n).ToArray();

        if (sortscores[5] == StaticNumberStore.thisgamescore)
        {
            ViewThankyou.SetChildrenActive(true);
            StartCoroutine(SceneChange());
        }
        else
        {
            StaticNumberStore.hiscores = sortscores;
            StartCoroutine(PutYourName());
        }
        IEnumerator SceneChange()
        {
            yield return new WaitForSeconds(5f);
            SceneManager.LoadScene("HighScoreScene");
        }
        IEnumerator PutYourName()
        {
            ViewRankin.SetChildrenActive(true);
            yield return new WaitForSeconds(3f);
            ViewRankin.SetChildrenActive(false);
            for (int i = 0; i < Scores.Count; i++)
            {
                SmoothDamp smoothDamp = Scores[i].GetComponent<SmoothDamp>();
                Vector2 pos = new Vector2(3, 0);
                smoothDamp.target += pos;
            }
            NameEntry.SetActive(true);
            yield break;
        }
    }
}