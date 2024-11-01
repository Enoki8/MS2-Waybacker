using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartWaiting : MonoBehaviour
{
    [SerializeField] NewPlayerController controller;
    [SerializeField] List<GameObject> Starts;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(StartWait());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator StartWait()
    {
        yield return new WaitForSeconds(1.5f);
        foreach (GameObject go in Starts) 
        {
            SmoothDamp smoothDamp = go.GetComponent<SmoothDamp>();
            smoothDamp.enabled = false;
            DropBlock dropBlock = go.GetComponent<DropBlock>();
            dropBlock.enabled = true;
        }
        controller.enabled = true;
        yield return new WaitForSeconds(1);

        foreach(GameObject go in Starts) 
        {
            Destroy(go);
        }
    }
}
