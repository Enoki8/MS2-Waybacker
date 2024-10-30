using UnityEngine;

public class HowTo1 : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] private int movespeed;
    [SerializeField] private int moveFlags = 0;
    // Start is called before the first frame update
    void Start()
    {
        animator.SetBool("Right", true);
        animator.SetBool("Walking", true);
    }

    // Update is called once per frame
    void Update()
    {

    }


}
