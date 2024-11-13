using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NameEntry : MonoBehaviour
{
    [SerializeField] List<GameObject> Alps;
    [SerializeField] KeyAttach KeyAttach;
    [SerializeField] FontStore FontStore;
    [SerializeField] GameObject NamaeIrete;
    [SerializeField] ResetNameEntry ResetNameEntry;
    [SerializeField] int position = 0;
    private int choosing;
    private bool EndCheck = false;
    [SerializeField] int[] entryname = new int[3] { -1, -1, -1 };
    // Start is called before the first frame update
    void Start()
    {
        NamaeIrete.SetActive(true);
        choosing = 0;
        ViewAlps(Posset());
    }

    // Update is called once per frame
    void Update()
    {
        if (!ResetNameEntry.TimeOver)
        {
            entryname[0] = 0;
            entryname[1] = 0;
            entryname[2] = 0;
            SetRankingName();
            EndCheck = true;
            SceneManager.LoadScene("HighScoreScene");

        }
        if (entryname[2] == -1)
        {
            int button = KeyAttach.Pushed();
            if (button != 0)
            {
                ViewAlps(Posset());
            }
            else if (KeyAttach.RetrurnKeyDown("A"))
            {
                Choose();
                entryname[choosing] = position;
                choosing++;
                if (entryname[2] != -1)
                {
                    foreach (GameObject child in Alps)
                    {
                        child.SetActive(false);
                    }
                }
            }
        }
        else if (!EndCheck)
        {
            SetRankingName();
            StartCoroutine(EndGame());
            EndCheck = true;
        }

    }
    private int[] Posset()
    {
        switch (KeyAttach.PushedDown())
        {
            case 3:
                position = position + 1;
                break;
            case 4:
                position = position - 1;
                break;
        }
        position = Replace(position);

        int[] alps = new int[9];
        for (int i = 0; i < alps.Length; i++)
        {
            alps[i] = Replace(position + (i - 4));
        }
        return alps;
    }

    private int Replace(int num)
    {
        if (num < 0)
        {
            num = 25 + (num + 1);
        }
        else if (num > 25)
        {
            num = 0 + (num - 26);
        }
        return num;
    }
    private void ViewAlps(int[] alps)
    {
        for (int i = 0; i < alps.Length; i++)
        {
            SpriteRenderer sr;
            sr = Alps[i].GetComponent<SpriteRenderer>();
            sr.sprite = FontStore.fonts[alps[i]];
        }
    }

    private void Choose()
    {
        GameObject clone = Clone(Alps[4]);
        for (int i = 0; i < Alps.Count; i++)
        {
            Vector2 pos = Alps[i].transform.position;
            pos.x += 1f;
            Alps[i].transform.position = pos;
        }
    }
    public GameObject Clone(GameObject obj)
    {
        var clone = GameObject.Instantiate(obj) as GameObject;
        clone.transform.parent = obj.transform.parent;
        clone.transform.localPosition = obj.transform.localPosition;
        clone.transform.localScale = obj.transform.localScale;
        return clone;
    }
    private void SetRankingName()
    {
        for (int i = 0; i < StaticNumberStore.hiscorename.Length; i++)
        {
            if (StaticNumberStore.hiscores[4 - i] == StaticNumberStore.thisgamescore)
            {
                for (int j = 0; j < 3; j++)
                {
                    StaticNumberStore.hiscorename[4 - i, j] = entryname[j];
                }
                break;
            }
            else
            {
                for (int j = 0; j < 3; j++)
                {
                    StaticNumberStore.hiscorename[4 - i, j] = StaticNumberStore.hiscorename[3 - i, j];
                }
            }
        }
    }

    IEnumerator EndGame()
    {
        NamaeIrete.SetActive(false);
        yield return new WaitForSeconds(5f);
        SceneManager.LoadScene("HighScoreScene");
    }
}
