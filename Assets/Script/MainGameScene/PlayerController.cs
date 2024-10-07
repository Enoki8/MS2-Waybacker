using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] CreateBlock createblock;
    [SerializeField] Director director;
    [SerializeField] ScoreManager scoreManager;
    [SerializeField] TimeManager timeManager;

    private int maxspace;
    [SerializeField] int space;
    [SerializeField] int button;
    public double uplimit;
    public int[] Locate = new int[2];

    void Start()
    {
        transform.position = new Vector3(-6, 1, -1);
        maxspace = 8;
        space = 0;
        button = 0;
        uplimit = 0;
    }

    void Update()
    {
        if (space == 0)
        {
            button = Wall(Pushed());
            Move();
        }
        if (space != 0)
        {
            Moveupdate();
        }
    }

    private void Moveupdate()
    {
        space--;
        Vector3 movement = Vector3.zero;

        switch (button)
        {
            case 1:
                movement = new Vector3(0.125f, 0f, 0f);
                break;
            case 2:
                movement = new Vector3(-0.125f, 0f, 0f);
                break;
            case 3:
                movement = new Vector3(0f, -0.125f, 0f);
                if (uplimit != 0)
                {
                    uplimit -= 0.125;
                }
                break;
            case 4:
                movement = new Vector3(0f, 0.125f, 0f);
                break;
        }
        transform.position += movement;
        if (space == 0)
        {
            if (button == 3 && uplimit == 0)
            {
                scoreManager.MaterUp();
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

    private void Move()
    {
        if (button != 0)
        {
            space = maxspace;

            switch (button)
            {
                case 1:
                    Locate[1]++;
                    break;
                case 2:
                    Locate[1]--;
                    break;
                case 3:
                    if (uplimit == 0)
                    {
                        createblock.Createrow();
                    }
                    Locate[0]++;
                    break;
                case 4:
                    uplimit++;
                    Locate[0]--;
                    break;
            }
            Debug.Log($"Locate0:{Locate[0]} Locate1:{Locate[1]}");
            createblock.Destroyblock(Locate[0], Locate[1]);
        }
    }

    private int Wall(int button)
    {
        if ((Locate[1] == 9 && button == 1) ||
            (Locate[1] == 0 && button == 2) ||
            (uplimit == 3 && button == 4))
        {
            return 0;
        }
        else
        {
            return button;
        }
    }
}