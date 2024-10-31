using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HowTo4 : MonoBehaviour
{
    [SerializeField] List<GameObject> Afterblocks;
    [SerializeField] List<GameObject> Descripts;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SetAfter()); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator SetAfter()
    {
        yield return new WaitForSeconds(3f);
        for(int i = 0; i < Afterblocks.Count; i++)
        {
            Afterblocks[i].SetActive(true);
        }
        yield return new WaitForSeconds(3f);
        Descripts[0].SetActive(false);
        yield return new WaitForSeconds(1f);
        Descripts[1].SetActive(true);
    }
}
