using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameOverDirector : MonoBehaviour
{
    [SerializeField] Director director;
    [SerializeField] CreateBlock createBlock;
    [SerializeField] DropBlock dropBlock;
    [SerializeField] AnimationDirector animationDirector;

    [SerializeField] GameObject Player;
    [SerializeField] GameObject NewPlayer;
    [SerializeField] GameObject timeManager;
    [SerializeField] GameObject Gameover;

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
            var comp = Player.GetComponent<NewPlayerController>();
            Destroy(comp);
            StartCoroutine(TakeScripts());
            director.getgameover = false;
        }
    }

    IEnumerator TakeScripts()
    {
        yield return new WaitForSeconds(1.5f);
        for (int i = createBlock.Grid.Count - 1; i > 0; i--)
        {
            List<GameObject> grids = createBlock.Grid[i];
            for (int j = 0; grids.Count > j; j++)
            {
                {
                    if (grids[j] != null)
                    {
                        grids[j].AddComponent<DropBlock>();

                    }
                    yield return new WaitForSeconds(0.005f);
                }
            }
            yield return new WaitForSeconds(0.05f);

        }
        yield return new WaitForSeconds(0.5f);
        animationDirector.FallingStart();
        yield return new WaitForSeconds(1.5f);
        NewPlayer.AddComponent<DropBlock>();
        yield return new WaitForSeconds(2f);
        SpriteRenderer spriteRenderer = Gameover.GetComponent<SpriteRenderer>();
        spriteRenderer.enabled = true;
        StaticNumberStore.thisgamescore = ScoreManager.GameScore;
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene("GameOverScene");
    }
}
