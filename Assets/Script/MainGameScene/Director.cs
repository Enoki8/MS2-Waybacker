using UnityEngine;

public class Director : MonoBehaviour
{
    [SerializeField] PlayerController player;
    [SerializeField] CreateBlock createblock;

    // Start is called before the first frame update
    void Start()
    {
        createblock.Createnull();
        for (int i = 0; i < 7; i++)
        {
            createblock.Createrow();
        }
    }
    // Update is called once per frame
    void Update()
    {

    }
}
