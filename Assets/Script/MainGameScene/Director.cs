using System.Collections.Generic;
using UnityEngine;

public class Director : MonoBehaviour
{
    [SerializeField] CreateBlock createblock;
    public bool getgameover = false;

    // Start is called before the first frame update
    void Start()
    {
        createblock.Createnull();
        for (int i = 0; i < 7; i++)
        {
            createblock.Createrow();
        }
        for (int i = 3; i < 6; i++)
        {
            for (int j = 1; j < 4; j++)
            {
                createblock.Destroyblock(j, i);

            }
        }
    }
    // Update is called once per frame
    //void Update()
    //{

    //}
}
