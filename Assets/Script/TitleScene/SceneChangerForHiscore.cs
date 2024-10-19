using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static Unity.Collections.AllocatorManager;

public class SceneChangerForHiscore : MonoBehaviour
{
    [SerializeField] GameObject Black;
    private string Scene = "HighScoreScene";
    [SerializeField] private float transparency;


    void Start()
    {
        StartCoroutine(SceneChange());
    }

    private void Update()
    {
        Black.GetComponent<SpriteRenderer>().color -= new Color(0, 0, 0, transparency);
    }
    // Update is called once per frame

    public IEnumerator SceneChange()
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(Scene);
    }
}
