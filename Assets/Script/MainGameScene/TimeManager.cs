using UnityEngine;
public class TimeManager : MonoBehaviour
{
    private RectTransform RectTransform;

    [SerializeField] double time;
    public static double static_time;
    private double beforetime;
    private double aftertime;

    public float shrinkSpeed = 0.5f;

    [SerializeField] GameObject Bar_1;
    [SerializeField] UIViewer UIViewer;
    [SerializeField] Director Director;
    [SerializeField] ScoreManager ScoreManager;

    void Start()
    {
        static_time = time;
        UIViewer.UIScrollList.Add(Bar_1);
        UIViewer.UIScrollList.Add(this.gameObject);
    }

    void Update()
    {
        //秒数を増やすところ
        if (time > 0)
        {
            float thistime = Mathf.Min(4,((1 + (ScoreManager.GameSteps) * 0.01f)));
            time -= Time.deltaTime * thistime;
            Vector2 pos = transform.position;
            float newpos = (float)((Time.deltaTime * thistime) * 10 / static_time);
            pos.y -= newpos;
            transform.position = pos;
        }
        else
        {
            if (!Director.getgameover)
            {
                Debug.Log("おわり");
                Director.getgameover = true;
            }
        }
    }
    //秒数を増やす処理
    public void Time_Additioner(int addition_time)
    {
        beforetime = (float)time;

        //Debug.Log($"{addition_time}Time_Addition!!!!");
        time += addition_time;
        if (time > static_time)
        {
            time = static_time;
        }
        aftertime = (float)time - beforetime;
        Vector2 pos = transform.position;
        float newpos = (float)((aftertime) * 10 / static_time);
        pos.y += newpos;
        transform.position = pos;
    }
}
