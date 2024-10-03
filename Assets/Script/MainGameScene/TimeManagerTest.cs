using UnityEngine;

public class TimeManagerTest : MonoBehaviour
{
    public int GameTime;
    // Start is called before the first frame update
    void Start()
    {
        GameTime = 100000;
    }

    // Update is called once per frame
    void Update()
    {
        GameTime--;
        if (GameTime < 2000)//ピンチ
        {
            Debug.Log("WARNING");
        }

    }
    public void CountUp(int upcount)
    { 
        GameTime += upcount;
        Debug.Log($"{upcount}回復");
    }
}
