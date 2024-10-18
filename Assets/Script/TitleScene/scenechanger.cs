using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class scenechanger : MonoBehaviour   
{  
    [SerializeField] string Scene = "HighScoreScene";
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SceneChanger());
    }

    // Update is called once per frame

    public IEnumerator SceneChanger()
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(Scene);
    }
}
