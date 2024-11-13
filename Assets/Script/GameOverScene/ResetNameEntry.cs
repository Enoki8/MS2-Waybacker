using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetNameEntry : MonoBehaviour
{
    public bool TimeOver =true;
    private float waitingmane;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        waitingmane += Time.deltaTime;
        if (waitingmane > 30)
        {
            TimeOver =false;
        }
        else
        {
            if (Input.anyKey)
            {
                waitingmane = 0;
            }
        }
    }
}
