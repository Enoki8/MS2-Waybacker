using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIViewer : MonoBehaviour
{
    public List<GameObject> UIScrollList;//スクロールさせるUIはここにぶち込む

    // Start is called before the first frame update
    //void Start()
    //{
    //    //UIScrollList = new List<GameObject>();
    //}

    //// Update is called once per frame
    //void Update()
    //{
        
    //}
    public void UICamera(Vector3 pos)//UI移動用
    {
        //Debug.Log(UIScrollList.Count);
        for (int i = 0; i < UIScrollList.Count; i++)
        {
            UIScrollList[i].transform.position += pos;
        }

    }
}
