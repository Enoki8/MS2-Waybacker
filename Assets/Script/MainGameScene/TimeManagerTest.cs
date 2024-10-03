using UnityEngine;

public class pTimeManager : MonoBehaviour
{
    public static double static_GameTime;
    [SerializeField] double GameTime = 100;
    [SerializeField] int upcount = 10;

    // Start is called before the first frame update
    void Start()
    {
        static_GameTime = GameTime;
    }

    // Update is called once per frame
    void Update()
    {
        GameTime -= Time.deltaTime;
        if (GameTime < 20)//ピンチ
        {
            Debug.Log("WARNING");
        }

    }
    public void CountUp(int upcount)
    { 
        static_GameTime += upcount;
        Debug.Log($"{upcount}回復");
    }
}
