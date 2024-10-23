using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationDirector : MonoBehaviour
{
    private Animator animator;
    private Vector3 beforevector;
    [SerializeField] GameObject place;
    [SerializeField] KeyAttach keyAttach;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        animator.SetBool("Left", false);
        animator.SetBool("Right", false);
        animator.SetBool("Up", false);
        animator.SetBool("Down", false);
    }

    // Update is called once per frame
    void Update()
    {
        if (beforevector != place.transform.position)
        {
            int button = keyAttach.Pushed();
            switch (button)
            {
                case 0:
                    animator.SetBool("Left", false);
                    animator.SetBool("Right", false);
                    animator.SetBool("Up", false);
                    animator.SetBool("Down", false);
                    animator.SetBool("Push", false);

                    break;
                case 1:
                    animator.SetBool("Left", false);
                    animator.SetBool("Right", true);
                    animator.SetBool("Up", false);
                    animator.SetBool("Down", false);
                    animator.SetBool("Push",true);

                    break;
                case 2:
                    animator.SetBool("Left", true);
                    animator.SetBool("Right", false);
                    animator.SetBool("Up", false);
                    animator.SetBool("Down", false);
                    animator.SetBool("Push", true);

                    break;
                case 3:
                    animator.SetBool("Left", false);
                    animator.SetBool("Right", false);
                    animator.SetBool("Up", false);
                    animator.SetBool("Down", true);
                    animator.SetBool("Push", true);

                    break;
                case 4:
                    animator.SetBool("Left", false);
                    animator.SetBool("Right", false);
                    animator.SetBool("Up", true);
                    animator.SetBool("Down", false);
                    animator.SetBool("Push", true);
                    break;
            }
        }
        else
        {
            animator.SetBool("Left",false);
            animator.SetBool("Right", false);
            animator.SetBool("Up", false);
            animator.SetBool("Down", false);
            animator.SetBool("Push", false);


        }
        beforevector = place.transform.position;

    }
}
