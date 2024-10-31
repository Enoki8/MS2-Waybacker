using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShadeHighScore : MonoBehaviour
{

    [SerializeField] KeyAttach KeyAttach;
    [SerializeField] Animator Animator;
    public bool demoended = false;
    // Start is called before the first frame update
    void Start()
    {
        StaticList.ingame = false;
        StaticNumberStore.thisgamescore = 0;
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
        StopCoroutine(SceneChange());
        Animator.SetBool("Shading", true);
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("TitleScene");
    }
    IEnumerator SceneChange()
    {
        StopCoroutine(StartLoad());
        yield return new WaitForSeconds(8f);
        Animator.SetBool("Shading", true);
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("LogoScene");

    }
}
