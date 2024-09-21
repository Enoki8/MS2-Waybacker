using UnityEngine;

public class Walk : MonoBehaviour
{
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.RightArrow) ||
            Input.GetKey(KeyCode.LeftArrow))
        {
            Debug.Log("test");
            //animator.SetBool("isWalking", true);
            if (Input.GetKey(KeyCode.RightArrow))
            {
                transform.position += new Vector3(0.05f, 0f, 0f);
            }
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                transform.position -= new Vector3(0.05f, 0f, 0f);
            }
        }
        else
        {
            //animator.SetBool("isWalking", false);
        }

    }
}
