using UnityEngine;

public class CursorController : MonoBehaviour
{
    [SerializeField] Renderer Renderer;
    [SerializeField] GameObject NewPlayer;
    [SerializeField] NewPlayerController NewPlayerController;
    [SerializeField] CreateBlock createBlock;
    [SerializeField] GameObject Flag;
    [SerializeField] KeyAttach KeyAttach;

    private int[] cursorLotate = new int[2];
    private bool[] flaglotate = new bool[2];
    private int thisflame;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (KeyAttach.RetrurnKey("B"))
        {
            if (KeyAttach.RetrurnKeyDown("B"))
            {
                cursorLotate = LotateCheck();
                //Debug.Log($"x;{cursorLotate[0]} y;{cursorLotate[1]}");
                Renderer.enabled = true;
            }
            thisflame = KeyAttach.PushedDown();
            if (thisflame != 0)
            {
                Cursormove(thisflame);

            }
            if (KeyAttach.RetrurnKeyDown("A"))
            {
                InsertFlag();
            }
        }
        if (Input.GetKey(KeyCode.O) == false)
        {
            Renderer.enabled = false;
        }
    }
    private int[] LotateCheck()
    {
        Vector3 pos = Vector3.zero;
        pos.x = Mathf.RoundToInt(NewPlayer.transform.position.x);
        pos.y = Mathf.RoundToInt(NewPlayer.transform.position.y);
        pos.z = -10;
        transform.position = pos;
        int[] lotate = new int[2] { (int)pos.x + 6, -((int)pos.y) }; // 4çs3óÒÇÃ2éüå≥îzóÒ
        return lotate;
    }

    private void Cursormove(int button)
    {
        Vector3 move = Vector3.zero;
        switch (button)
        {
            case 1:
                if (cursorLotate[0] < 9)
                {
                    move = new Vector3(1, 0, 0);
                    cursorLotate[0]++;
                }
                break;
            case 2:
                if (cursorLotate[0] > 0)
                {
                    move = new Vector3(-1, 0, 0);
                    cursorLotate[0]--;
                }
                break;
            case 3:
                if (cursorLotate[1] <= -(Mathf.RoundToInt(NewPlayer.transform.position.y) - 3))
                {
                    move = new Vector3(0, -1, 0);
                    cursorLotate[1]++;
                }
                break;
            case 4:
                if (cursorLotate[1] >= -(Mathf.RoundToInt(NewPlayer.transform.position.y) + 3))
                {
                    if (cursorLotate[1] != 0)
                    {
                        move = new Vector3(0, 1, 0);
                        cursorLotate[1]--;
                    }
                }
                break;
        }
        transform.position += (move);
    }
    private void InsertFlag()
    {
        createBlock.CreateFlags(cursorLotate[0], cursorLotate[1] + 1);
    }
}
