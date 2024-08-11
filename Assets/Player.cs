using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] CreateBlock createblock;
    [SerializeField] Director director;
    private int maxspace;
    [SerializeField] int space;
    [SerializeField] int button;
    public double uplimit;
    public int[] Locate = new int[2];

    // Start is called before the first frame update
    void Start()
    {
        transform.position = Vector2.zero;
        maxspace = 8;
        space = 0;
        button = 0;
        uplimit = 0;
    }


    // Update is called once per frame
    void Update()
    {
        if (space == 0)
        {
            button = Wall(Pushed());
            if (Input.GetMouseButtonDown(0))
            {
                Move();
            }

        }
        if (space != 0)
        {
            Moveupdate();
        }
    }

    private void Moveupdate()
    {
        space--;
        if (button == 1)
        {
            transform.position += new Vector3(0.125f, 0f, 0f);
        }
        if (button == 2)
        {
            transform.position += new Vector3(-0.125f, 0f, 0f);
        }
        if (button == 3)
        {
            transform.position += new Vector3(0f, -0.125f, 0f);
            if (uplimit != 0)
            {
                uplimit = uplimit - 0.125;
            }
        }
        if (button == 4)
        {
            transform.position += new Vector3(0f, 0.125f, 0f);
        }
    }


    private int Pushed()
    {
        if (Input.GetKey(KeyCode.RightArrow) && Input.GetKey(KeyCode.LeftArrow) ||
            Input.GetKey(KeyCode.UpArrow) && Input.GetKey(KeyCode.DownArrow)
            )
        {
            return 0;
        }
        else
        {
            if (Input.GetKey(KeyCode.RightArrow))
            {
                return 1;
            }
            else if (Input.GetKey(KeyCode.LeftArrow))
            {
                return 2;
            }
            else if (Input.GetKey(KeyCode.DownArrow))
            {
                return 3;
            }
            else if (Input.GetKey(KeyCode.UpArrow))
            {
                return 4;
            }
            else
            {
                return 0;
            }
        }
    }
    private void Move()
    {
        if (button != 0)
        {
            space = maxspace;
            if (button == 1)
            {
                Locate[1]++;
            }
            if (button == 2)
            {
                Locate[1]--;
            }
            if (button == 3)
            {
                if (uplimit == 0)
                {
                    createblock.Createrow();
                }
                Locate[0]++;
            }
            if (button == 4)
            {
                uplimit++;
                Locate[0]--;

            }
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