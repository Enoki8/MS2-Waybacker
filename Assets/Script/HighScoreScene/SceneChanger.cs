using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    [SerializeField] string Scene = "TitleScene";

    void Start()
    {
        StartCoroutine(SceneChange());
    }

    // Update is called once per frame

    public IEnumerator SceneChange()
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(Scene);
    }
}
