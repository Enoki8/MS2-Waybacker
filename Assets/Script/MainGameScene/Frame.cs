using UnityEngine;

public class Frame : MonoBehaviour
{
    private float startTime; // ŠJŽnŽžŠÔ

    void Start()
    {
        startTime = Time.time;
        Application.targetFrameRate = 60;
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.F))
        {
            var nowTime = Time.time;
            var elapsedTime = nowTime - startTime;
            Debug.Log($"fps: {Time.frameCount / elapsedTime}");
        }
    }
}