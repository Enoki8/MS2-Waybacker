using UnityEngine;

public class NewPlayerController : MonoBehaviour
{
    [SerializeField] CreateBlock createblock;
    [SerializeField] Director director;
    [SerializeField] ScoreManager scoreManager;
    [SerializeField] TimeManager timeManager;
    [SerializeField] GameObject newplayer;
    private int thisflame;
    private bool thisflamecorrect;
    [SerializeField] int xzahyou;
    [SerializeField] int yzahyou;

    public  float walkingspeed;
    [SerializeField] int[] PlayerGrids;
    [SerializeField] int[] Destroyblock;

    public int uplimit;

    // Start is called before the first frame update
    void Start()
    {
        PlayerGrids = new int[2];
        Destroyblock = new int[2];
        transform.position = new Vector3(-6, 1, -1);
        newplayer.transform.position = transform.position;
        thisflame = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.R)==false)
        {
            thisflame = Pushed();
            if (thisflame != 0)
            {
                if (WallCheck(thisflame) != 0)
                {
                    Walking(thisflame);
                    Destroyblock = PlayerGridCheck(thisflame);
                    if (Destroyblock != null && createblock.boolsGrid[Destroyblock[1]][Destroyblock[0]] != true)
                    {

                        if (Input.GetKey(KeyCode.P))
                        {
                            //Debug.Log($"Locate0:{Destroyblock[1]} Locate1:{Destroyblock[0]}");
                            createblock.Destroyblock(Destroyblock[1], Destroyblock[0]);
                        }
                        transform.position = newplayer.transform.position;

                    }
                    thisflamecorrect = BlockCorrection(thisflame);
                    if (thisflamecorrect == true)
                    {
                        transform.position = newplayer.transform.position;
                    }
                    else
                    {
                        newplayer.transform.position = transform.position;
                    }
                }
                newplayer.transform.position = transform.position;
                MaterCheck();
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
            return 0;
        }
        if (transform.position.x >= 3 && button == 1)
        {
            Vector3 pos = transform.position;
            pos.x = 3;
            transform.position = pos;
            return 0;
        }

        if ((scoreManager.GameSteps - 4 >= -(transform.position.y)) && button == 4)
        {
            return 0;
        }
        return button;
    }

    private void Walking(int button)
    {        Vector3 move = Vector3.zero;
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

    private int[] PlayerGridCheck(int button)
    {
        int[] result = new int[2];
        Vector3 playerPos = transform.position;
        xzahyou = Mathf.RoundToInt(playerPos.x) + 6;
        yzahyou = -(Mathf.RoundToInt(playerPos.y));
        switch (button)
        {
            case 1:
                if (xzahyou < transform.position.x + 6)
                {
                    result[0] = xzahyou + 1;
                    result[1] = yzahyou + 1;

                    Vector3 pos = newplayer.transform.position;
                    pos.x = Mathf.RoundToInt(transform.position.x);
                    newplayer.transform.position = pos;

                    return result;
                }
                break;
            case 2:
                if (xzahyou > transform.position.x + 6)
                {
                    result[0] = xzahyou - 1;
                    result[1] = yzahyou + 1;

                    Vector3 pos = newplayer.transform.position;
                    pos.x = Mathf.RoundToInt(transform.position.x);
                    newplayer.transform.position = pos;

                    return result;
                }
                break;
            case 3:
                if (yzahyou < -(transform.position.y))
                {
                    result[0] = xzahyou;
                    result[1] = yzahyou + 2;

                    Vector3 pos = newplayer.transform.position;
                    pos.y = Mathf.RoundToInt(transform.position.y);
                    newplayer.transform.position = pos;

                    return result;
                }
                break;
            case 4:
                if (yzahyou > -(transform.position.y))
                {
                    result[0] = xzahyou;
                    result[1] = yzahyou;

                    Vector3 pos = newplayer.transform.position;
                    pos.y = Mathf.RoundToInt(transform.position.y);
                    newplayer.transform.position = pos;

                    return result;
                }
                break;
        }
        return null;
    }
    private bool BlockCorrection(int button)
    {
        switch (button)
        {
            case 1:
                if ((int)transform.position.y != transform.position.y)
                {
                    Vector3 pos = newplayer.transform.position;
                    pos.y = Mathf.RoundToInt(transform.position.y);
                    newplayer.transform.position = pos;
                    //Debug.Log(newplayer.transform.position.y);
                    return true;
                }
                break;
            case 2:
                if ((int)transform.position.y != transform.position.y)
                {
                    Vector3 pos = newplayer.transform.position;
                    pos.y = Mathf.RoundToInt(transform.position.y);
                    newplayer.transform.position = pos;
                    //Debug.Log(newplayer.transform.position.y);
                    return true;
                }
                break;
            case 3:
                if ((int)transform.position.x != transform.position.x)
                {
                    Vector3 pos = newplayer.transform.position;
                    pos.x = Mathf.RoundToInt(transform.position.x);
                    newplayer.transform.position = pos;
                    return true;
                }
                break;
            case 4:
                if ((int)transform.position.x != transform.position.x)
                {
                    Vector3 pos = newplayer.transform.position;
                    pos.x = Mathf.RoundToInt(transform.position.x);
                    newplayer.transform.position = pos;
                    return true;
                }
                break;

        }
        return false;
    }
    private void MaterCheck()
    {
        Vector3 playerPos = newplayer.transform.position;
        if (scoreManager.GameSteps < -(Mathf.RoundToInt(playerPos.y) - 1))
        {
            scoreManager.MaterUp();
            createblock.Createrow();
        }
    }

}