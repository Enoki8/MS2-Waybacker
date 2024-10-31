using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Shade : MonoBehaviour
{
    [SerializeField] KeyAttach KeyAttach;
    [SerializeField] Animator Animator;
    public bool demoended=false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (demoended)
        {
            StartCoroutine(StartLoad());
        }
        if (KeyAttach.RetrurnKey("A"))
        {
            StartCoroutine (PushStart());
        }
    }
    IEnumerator StartLoad()
    {
        Animator.SetBool("Shading", true);
        yield return new WaitForSeconds(1);
        if (StaticList.ingame)
        {
            SceneManager.LoadScene("MainScene");
        }
        else 
        {
            SceneManager.LoadScene("HighScoreScene");
        }

    }
    IEnumerator PushStart()
    {
        {
            Animator.SetBool("Shading", true);
            yield return new WaitForSeconds(1);
        }
        if (StaticList.ingame)
        {
            SceneManager.LoadScene("MainScene");
        }
        else
        {
            SceneManager.LoadScene("TitleScene");
        }
    }
}
