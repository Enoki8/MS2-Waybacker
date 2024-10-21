using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushAControll : MonoBehaviour
{
    [SerializeField] SmoothDamp smoothDamp;
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator= GetComponent<Animator>();
        animator.SetBool("CompMove", false);
    }

    // Update is called once per frame
    void Update()
    {
        if (smoothDamp.CompScroll)
        {
            animator.SetBool("CompMove", true);
        }
    }
}
