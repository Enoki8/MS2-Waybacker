using System.Collections.Generic;
using UnityEngine;

public class WalkingFloat : MonoBehaviour
{
    [SerializeField] List<GameObject> Floats;
    private List<bool> incamera;
    [SerializeField] private float movespeed = 0.008f;
    // Start is called before the first frame update
    void Start()
    {
        incamera = new List<bool>(4) { false, false, false, false };
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i <= 3; i++)
        {
            if (incamera[i] == false)
            {   int rnd=Random.Range(0,500);
                if (rnd == 0)
                {
                    incamera[i] = true;
                    switch (i)
                    {
                        case 0:
                            Floats[0].transform.position = new Vector3(8, Random.Range(-4.5f, 4.5f), 5);
                            break;
                        case 1:
                            Floats[1].transform.position = new Vector3(-8, Random.Range(-4.5f, 4.5f), 5);
                            break;
                        case 2:
                            Floats[2].transform.position = new Vector3(Random.Range(-7.0f, 7.0f), 5.5f, 5);
                            break;
                        case 3:
                            Floats[3].transform.position = new Vector3(Random.Range(-7.0f, 7.0f), -5.5f, 5);
                            break;
                    }
                }
            }
            else
            {
                Vector3 pos = Floats[i].transform.position;
                float move=movespeed*Time.deltaTime;
                switch (i)
                {
                    case 0:
                        pos.x = pos.x - move;
                        Floats[0].transform.position = pos;
                        if (pos.x < -8)
                        {
                            incamera[i] = false;
                        }
                        break;
                    case 1:
                        pos.x = pos.x + move;
                        Floats[1].transform.position = pos;
                        if (pos.x > 8)
                        {
                            incamera[i] = false;
                        }
                        break;
                    case 2:
                        pos.y = pos.y - move;
                        Floats[2].transform.position = pos;
                        if (pos.y < -5.5f)
                        {
                            incamera[i] = false;
                        }
                        break;
                    case 3:
                        pos.y = pos.y + move;
                        Floats[3].transform.position = pos;
                        if (pos.y > 5.5f)
                        {
                            incamera[i] = false;
                        }
                        break;
                }
            }
        }
    }
}
