using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShadeTitle : MonoBehaviour
{

    [SerializeField] KeyAttach KeyAttach;
    [SerializeField] Animator Animator;
    public bool demoended = false;
    // Start is called before the first frame update
    void Start()
    {
        StaticList.ingame = false;
        StartCoroutine(SceneChange());
    }

    // Update is called once per frame
    void Update()
    {
        if (KeyAttach.RetrurnKey("A"))
        {
            StartCoroutine(StartLoad());
        }
    }
    IEnumerator StartLoad()
    {
        StaticList.ingame = true;
        StopCoroutine(SceneChange());
        Animator.SetBool("Shading", true);
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("HowToScene");
    }
    IEnumerator SceneChange()
    {
        yield return new WaitForSeconds(12f);
        StopCoroutine(StartLoad());
        Animator.SetBool("Shading", true);
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("HowToScene");

    }
}