using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class TitleDirector : MonoBehaviour
{
    [SerializeField] KeyAttach KeyAttach;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
     if (KeyAttach.RetrurnKey("A"))
        {
            StaticList.ingame = true;
        }   
    }
}
