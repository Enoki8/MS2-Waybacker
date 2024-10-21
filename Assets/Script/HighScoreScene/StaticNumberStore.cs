using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticNumberStore : MonoBehaviour
{
    public static int[] hiscores = new int[5] {50000,40000,30000,20000,10000};
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