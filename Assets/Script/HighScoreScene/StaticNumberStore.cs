using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticNumberStore : MonoBehaviour
{
    [SerializeField] public static int thisgamescore;
    public static int[] hiscores = new int[5] {5000,4000,3000,2000,1000};
    public static int[,] hiscorename = new int[5, 3]{
    {4,13,10},
    {8,13,19},
    {0,17,22},
    {19,4,0},
    {3,5,18},
    };

    public static int[] ReturnHiscores()
    { 
        return hiscores;
    }
    public static int[,] ReturnHiscoresName()
    {
        return hiscorename;
    }


}