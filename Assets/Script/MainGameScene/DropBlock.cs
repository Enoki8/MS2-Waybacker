using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DropBlock : MonoBehaviour
{
    [SerializeField] private float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        speed++;
        Vector2 pos = transform.position;
        pos.y -=speed * Time.deltaTime;
        transform.position = pos;
    }
}
