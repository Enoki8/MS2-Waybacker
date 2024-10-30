using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HowToDirector : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator StartHowto()
    {
        yield return new WaitForSeconds(5f);

        yield return null;
    }
}
