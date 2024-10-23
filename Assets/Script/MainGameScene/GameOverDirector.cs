using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverDirector : MonoBehaviour
{
    [SerializeField] Director director;
    [SerializeField] CreateBlock CreateBlock;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (director.getgameover)
        {
            Debug.Log("Gameover");
        }
    }
}
