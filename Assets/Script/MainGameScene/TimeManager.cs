﻿using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
public class  TimeManager : MonoBehaviour
{
    private RectTransform RectTransform;

    [SerializeField] double time = 100;
    [SerializeField] int addition_time = 10;
    public static double static_time;
    double get_keytime = 0.5;
    double input_time = 0;
    private double beforetime;
    private double aftertime;

    public float shrinkSpeed = 0.5f;

    [SerializeField] GameObject Bar_1;
    [SerializeField] UIViewer UIViewer;
    
    void Start()
    {
        static_time = time;
        UIViewer.UIScrollList.Add(Bar_1);
        UIViewer.UIScrollList.Add(this.gameObject);

        RectTransform.pivot = new Vector2(RectTransform.pivot.x, 0);
    }

    void Update()
    {
        //秒数を増やすところ
        if (time > 0)
        {
            time -= Time.deltaTime;
        }
        else
        {
            Debug.Log("おわり");
        }
        Vector2 pos=transform.position;
        float newpos = (float)((Time.deltaTime)*0.1);
        pos.y -= newpos;
        transform.position = pos;
    }
    //秒数を増やす処理
    public void Time_Additioner(int addition_time)
    {
        beforetime = (float)time;

        //Debug.Log($"{addition_time}Time_Addition!!!!");
        time += addition_time;
        if (time > 100) 
        {
            time = 100;
        }
        aftertime = (float)time-beforetime;
        Vector2 pos = transform.position;
        float newpos = -(float)((aftertime) * 0.1);
        pos.y -= newpos;
        transform.position = pos;
    }
}
