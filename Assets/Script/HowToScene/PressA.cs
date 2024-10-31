using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressA : MonoBehaviour
{
    [SerializeField] Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator.SetBool("CompMove", true); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
