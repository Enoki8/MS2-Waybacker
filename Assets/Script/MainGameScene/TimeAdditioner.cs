using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeAdditioner : MonoBehaviour
{   
    [SerializeField] double addition_time = 100;
    private double input_time = 0;
    [SerializeField] double get_keytime = 0.5;
    double t;
    void Start()
    {

    }
    void Update()
    {
        if (Input.GetKey(KeyCode.RightControl))
        {
            if ((input_time += Time.deltaTime) > get_keytime)
            {
                Debug.Log("Time_Addition!!!!" + addition_time);
                t += addition_time;
                input_time = 0;
            }
        }
    }
}