using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public int GameScore;
    public int GameMater;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    public void ScoreUp(int score)
    {
        GameScore += score;
        Debug.Log($"Score:{GameScore}");
    }
    public void MaterUp()
    {
        GameMater += 1;
        Debug.Log($"Mater:{GameMater}");
    }
}
