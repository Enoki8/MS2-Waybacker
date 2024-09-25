using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class HitCube : MonoBehaviour
{
    private UnityEvent Ondestroyed = new UnityEvent();
    public int cuberow;
    public int cubecolumn;
    public List<List<GameObject>> Grid = new List<List<GameObject>>();
    public List<List<int>> BombGrid = new List<List<int>>();
    [SerializeField] int zokusei;
    [SerializeField] int bombcount;

    // Start is called before the first frame update
    void Start()
    {
        bombcount = BombGrid[cubecolumn].Count;
        zokusei = BombGrid[cubecolumn][cuberow];
    }
    //private void AroundSand()
    //{

    //}

    // Update is called once per frame
    //void Update()
    //{

        //if (Input.GetKey(KeyCode.D))
        //{
        //    Debug.Log(BombGrid[cubecolumn][cuberow]);
        //    Destroy(this.gameObject);
        //}

    //}
    //private void OnDestroy()
    //{

    //}
}