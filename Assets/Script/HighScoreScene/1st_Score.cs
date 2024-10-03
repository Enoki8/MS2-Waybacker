using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;


public class first_score : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI testText;
    int Score = ScoreManager.GameScore;
    int[] Score_list = new int[5] { 5, 4, 3, 2, 1 };
    int[] Sub_Score_list = new int[4] { 5, 4, 3, 2 };
    int flag = 0;
    int Score_Ranker()
    {
        if (Score > Score_list[4] && Score < Score_list[3])
        {
            Score_list[4] = Score;
        }
        else
        {
            for (int i = 0; i < 4; i++)
            {
                if (Score > Score_list[i])
                {
                    Score_list[i] = Score;
                    flag = 1;
                    break;
                }
            }
            if (flag == 1)
            {
                Array.Copy(Sub_Score_list, 0, Score_list, 1, 4);
                Array.Copy(Score_list, Sub_Score_list, 4);
            }
        }
        Debug.Log("1st" + Score_list[0]);
        return Score_list[0];
    }
    // Start is called before the first frame update
    void Start()
    {

        testText.SetText("{0}", Score_Ranker());
    }

    // Update is called once per frame
}
