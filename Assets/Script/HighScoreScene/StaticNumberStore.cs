using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticNumberStore : MonoBehaviour
{
    public static int[] hiscores = new int[5] {50000,40000,30000,20000,10000};
    public static int[,] hiscorename = new int[5, 3]{
    {4,13,10},
    {0,1,2},
    {3,4,5},
    {6,7,8},
    {9,10,11},
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