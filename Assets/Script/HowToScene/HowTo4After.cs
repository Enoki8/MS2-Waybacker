using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HowTo4After : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            Transform child = transform.GetChild(i);
            SpriteRenderer renderer = child.GetComponent<SpriteRenderer>();
            Color color = renderer.color;
            color.a = 0f;
            renderer.color = color;
        } 
        
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            Transform child = transform.GetChild(i);
            SpriteRenderer renderer = child.GetComponent<SpriteRenderer>();
            Color color = renderer.color;
            if (color.a <= 10f) // 完全に不透明でない場合に透明度を上げる
            {
                color.a += 0.01f;// 透明度を少しずつ増加
                renderer.color = color;
            }
        }
    }
}
