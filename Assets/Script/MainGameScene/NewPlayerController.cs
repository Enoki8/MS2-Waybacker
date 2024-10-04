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

    [SerializeField] float walkingspeed;
    [SerializeField] int[] PlayerGrids;

    // Start is called before the first frame update
    void Start()
    {
        PlayerGrids = new int[2];
        transform.position = new Vector3(-6, 1, -1);
        thisflame = 0;
    }

    // Update is called once per frame
    void Update()
    {
        thisflame = Pushed();
        if (thisflame != 0)
        {
            if (WallCheck(thisflame) != 0)
            {
                Walking(thisflame);
                BlockCheck(thisflame);
            }
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
        if
            (transform.position.x <= -6 && button == 2)
        {
            Vector3 pos = transform.position;
            pos.x = -6;
            transform.position = pos;
            Debug.Log("•Ç‚Å‚·");
            return 0;
        }
        if (transform.position.x >= 3 && button == 1)
        {
            Vector3 pos = transform.position;
            pos.x = 3;
            transform.position = pos;
            Debug.Log("•Ç‚Å‚·");
            return 0;
        }
        return button;
    }
    private void BlockCheck(int button)
    {
        Vector3 playerPos = transform.position;
        xzahyou = Mathf.RoundToInt(playerPos.x);
        yzahyou = Mathf.RoundToInt(playerPos.y);
        Debug.Log($"x={xzahyou} y={yzahyou}");
    }

    private void Walking(int button)
    {
        Vector3 move = Vector3.zero;
        switch (button)
        {
            case 1:
                move = new Vector3(walkingspeed, 0, 0);
                break;
            case 2:
                move = new Vector3(-walkingspeed, 0, 0);
                break;
            case 3:
                move = new Vector3(0, -walkingspeed, 0);
                break;
            case 4:
                move = new Vector3(0, walkingspeed, 0);
                break;
        }

        transform.position += (move * Time.deltaTime);
    }

    private void PlayerGridCheck()
    {

    }
}
