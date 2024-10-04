using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class scenechanger : MonoBehaviour   
{  
    [SerializeField] float count = 3;
    [SerializeField] string Scene = "HighScoreScene";
    public static double timer=0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       SceneChanger(Scene,count);
    }
    public void SceneChanger(string Scene, float count)
    {
        if( Time.time-scenechanger.timer> count )
        {
            scenechanger.timer += Time.time;
            SceneManager.LoadScene(Scene);
        }
    }
}
