using System.Collections;
using TreeEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChangerForTitle : MonoBehaviour
{
    private string Scene = "TitleScene";
    [SerializeField] private float transparency;

    void Start()
    {
        StartCoroutine(SceneChange());
    }

    // Update is called once per frame

    public IEnumerator SceneChange()
    {
        yield return new WaitForSeconds(3);
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(Scene);
    }
}
