using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class  TimeManager : MonoBehaviour
{
    [SerializeField] double time = 100;
    [SerializeField] int addition_time = 10;
    public static double static_time;
    double t = 0;
    double get_keytime = 0.5;
    double input_time = 0;
    
    void Start()
    {
        static_time = time;
    }

    void Update()
    {
        //•b”‚ğ‘‚â‚·‚Æ‚±‚ë
        if (Input.GetKey(KeyCode.RightControl))
        {
            if ((input_time += Time.deltaTime) > get_keytime)
            {
                Time_Additioner(addition_time);
                input_time = 0;
            }
        }

        if (time > 0)
        {
            if ((t += Time.deltaTime) > 1)
            {
                Debug.Log(time);
                t = 0;
            }
            time -= Time.deltaTime;
        }
        else
        {
            Debug.Log("‚¨‚í‚è");
        }
    }
    //•b”‚ğ‘‚â‚·ˆ—
    public void Time_Additioner(int addition_time)
    {
                Debug.Log($"{addition_time}Time_Addition!!!!");
                time += addition_time;
    }
}
