using UnityEngine;

public class NewPlayerController : MonoBehaviour
{
    [SerializeField] CreateBlock createblock;
    [SerializeField] Director director;
    [SerializeField] ScoreManager scoreManager;
    [SerializeField] TimeManager timeManager;
    private int thisflame;
    [SerializeField] int xzahyou;
    [SerializeField] int yzahyou;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(-6, 1, -1);
        thisflame = 0;
    }

    // Update is called once per frame
    void Update()
    {
        thisflame = Pushed();
        if (thisflame != 0)
        {
            thisflame = WallCheck(thisflame);
        }
            //Debug.Log($"int={(int)transform.position.x} new={transform.position.x}");
            if ((int)transform.position.x == transform.position.x)
            {
                //Debug.Log("test");
                BlockCheck(thisflame);
            }
    }

    private int Pushed()
    {
        if ((Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.A)) ||
            (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.S)))
        {
            return 0;
        }

        if (Input.GetKey(KeyCode.D)) return 1;
        if (Input.GetKey(KeyCode.A)) return 2;
        if (Input.GetKey(KeyCode.S)) return 3;
        if (Input.GetKey(KeyCode.W)) return 4;

        return 0;
    }
    private int WallCheck(int button)
    {
        if (
            (transform.position.x == -6 && button == 2) ||
            (transform.position.x == 3 && button == 1)
            )
        {
            Debug.Log("壁です");
            return 0;
        }
        return button;
    }
    private void BlockCheck(int button)
    {
        xzahyou = (int)transform.position.x+6;
        yzahyou = -((int)transform.position.y);
        if (button == 1)
        {
            Debug.Log($"左を調べます 左のブロック；{xzahyou - 1}");
        }
        if (button == 2)
        {
            Debug.Log($"右を調べます 右のブロック；{xzahyou + 1}");
        }
        if (
        (button == 1 && createblock.Grid[xzahyou - 1][yzahyou] != null) ||
        (button == 2 && createblock.Grid[xzahyou + 1][yzahyou] != null))
        {
            Debug.Log("ブロックです");
        }
    }
}
