using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class TimeManager : MonoBehaviour
{
    [SerializeField] double time = 100;
    public static double static_time;
    double t = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        static_time = time;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (static_time > 0)
        {
            if ((t += Time.deltaTime) > 1)
            {
                Debug.Log(static_time);
                t = 0;
            }
            static_time -= Time.deltaTime;
        }
        else
        {
            Debug.Log("‚¨‚í‚è");
        }
    }
}