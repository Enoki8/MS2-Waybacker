using UnityEngine;

public class HowTo1 : MonoBehaviour
{
    [SerializeField] Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator.SetBool("HowTo1", true);
    }

    // Update is called once per frame
    void Update()
    {

    }


}
