using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushAControll : MonoBehaviour
{
    [SerializeField] SmoothDamp smoothDamp;
    [SerializeField] GameObject Enoki;
    private Animator animator;
    private SpriteRenderer spriteRenderer;
    // Start is called before the first frame update
    void Start()
    {
        animator= GetComponent<Animator>();
        spriteRenderer=Enoki.GetComponent<SpriteRenderer>();
        animator.SetBool("CompMove", false);
    }

    // Update is called once per frame
    void Update()
    {
        if (smoothDamp.CompScroll)
        {
            animator.SetBool("CompMove", true);
            spriteRenderer.enabled = true;
        }
    }
}
