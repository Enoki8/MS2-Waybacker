using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FadeAnimation : MonoBehaviour
{
    private Animator animator;
    private float timeElapsed = 0f;
    [SerializeField] private float delay;
    private bool hasTriggeredFadeOut = false;
    [SerializeField] private string scenename;
    [SerializeField] private string PUSHscenename;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        animator.SetBool("Fadeoutanim", false);
        animator.SetBool("Fadeinanim", true);
    }

    // Update is called once per frame
    void Update()
    {
        timeElapsed += Time.deltaTime;

        if ((Input.anyKeyDown ||timeElapsed >= delay) && !hasTriggeredFadeOut)
        {
            if (Input.anyKey)
            {
                scenename = PUSHscenename;
            }
            hasTriggeredFadeOut = true;
            StartCoroutine(FadeOutAndLoadScene(scenename));
        }
    }
    IEnumerator FadeOutAndLoadScene(string scenename)
    {
        animator.SetBool("Fadeinanim", false);
        animator.SetBool("Fadeoutanim", true);
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(scenename);
    }
}
