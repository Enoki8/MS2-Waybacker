using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameOverDirector : MonoBehaviour
{
    [SerializeField] Director director;
    [SerializeField] CreateBlock createBlock;
    [SerializeField] DropBlock dropBlock;
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
            StartCoroutine(TakeScripts());
        }
    }

    IEnumerator TakeScripts()
    {
        yield return new WaitForSeconds(1f);
    }
}
