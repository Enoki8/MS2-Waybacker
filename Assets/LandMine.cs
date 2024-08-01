using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class LandMine : MonoBehaviour
{
    public List<List<GameObject>> Grid = new List<List<GameObject>>();
    public List<List<int>> BombGrid = new List<List<int>>();
    public UnityEvent Ondestroyed = new UnityEvent();
    public int bombrow;
    public int bombcolumn;
    [SerializeField] int zokusei;
    [SerializeField] int bombcount;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        zokusei = BombGrid[bombcolumn][bombrow];
    }
    private void OnDestroy()
    {
        Ondestroyed.Invoke();
    }
}