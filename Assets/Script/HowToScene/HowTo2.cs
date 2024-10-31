using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HowTo2 : MonoBehaviour
{
    [SerializeField] List<GameObject> list;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(BreakBlock());   
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator BreakBlock()
    {
        yield return new WaitForSeconds(2.7f);
        Destroy(list[2]);
        yield return new WaitForSeconds(1f);
        Destroy(list[1]);
        yield return new WaitForSeconds(1f);
        Destroy(list[0]);

        yield return null;
    }
}
