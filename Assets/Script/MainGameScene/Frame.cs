﻿using UnityEngine;

public class Frame : MonoBehaviour
{
    private float startTime; // 開始時間

    void Start()
    {
        startTime = Time.time;
        Application.targetFrameRate = 144;
    }

    //void Update()
    //{
    //    if (Input.GetKey(KeyCode.F))
    //    {
    //        var nowTime = Time.time;
    //        var elapsedTime = nowTime - startTime;
    //        Debug.Log($"fps: {Time.frameCount / elapsedTime}");
    //    }
    //}
}