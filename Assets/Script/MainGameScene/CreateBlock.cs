﻿using System.Collections.Generic;
using UnityEngine;
public class CreateBlock : MonoBehaviour
{
    [SerializeField] ScoreManager scoreManager;
    [SerializeField] Director director;

    [SerializeField] GameObject sand;
    [SerializeField] GameObject mine;
    [SerializeField] PlayerController player;
    [SerializeField] GameObject blocksclone;
    public Sprite[] hints;
    public Sprite flag;
    public Sprite bomb;
    public Sprite nullblock;
    public Sprite null2;

    public List<List<GameObject>> Grid = new List<List<GameObject>>();
    List<List<int>> BombGrid = new List<List<int>>();
    public List<List<bool>> boolsGrid = new List<List<bool>>();

    public int destroycolumn = 0;
    public int column = 0;
    public int row = 0;
    // Start is called before the first frame update
    void Start()
    {

    }
    // Update is called once per frame
    //void Update()
    //{

    //    Debug.Log($"gridcount:{Grid.Count} bombgrid:{BombGrid.Count}");
    //}
    public void Destroyblock(int column, int row)//ブロック壊す
    {
        if (boolsGrid[column][row] != true)
        {
            boolsGrid[column][row] = true;
            int zokusei = BombGrid[column][row];
            //Debug.Log($"zokusei:{zokusei}");
            if (zokusei == 0)
            {
                Destroy(Grid[column - destroycolumn][row]);
                //SpriteRenderer sr;
                //sr = Grid[column - destroycolumn][row].GetComponent<SpriteRenderer>();
                //sr.sprite = n;
            }
            else
            {
                //Debug.Log("画像変更");
                SpriteRenderer sr;
                sr = Grid[column - destroycolumn][row].GetComponent<SpriteRenderer>();
                if (zokusei == -1)
                {
                    sr.sprite = bomb;
                    director.getgameover = true;
                }
                else
                {
                    sr.sprite = hints[zokusei];
                    scoreManager.ScoreUp(zokusei * 100);
                }
            }
        }

    }


    public void Createnull()
    {
        List<GameObject> Row = new List<GameObject>();
        List<int> BombRow = new List<int>();
        List<bool> boolRow = new List<bool>();
        for (row = 0; row < 10; row++)
        {
            Row.Add(null);
            BombRow.Add(0);
            boolRow.Add(false);
        }
        Grid.Add(Row);
        BombGrid.Add(BombRow);
        BombGrid.Add(BombRow);
        boolsGrid.Add(boolRow);
        column++;
    }


    public void Createrow()//ブロック作る
    {
        List<GameObject> Row = new List<GameObject>();
        List<int> BombRow = new List<int>();
        List<bool> boolRow = new List<bool>();
        for (row = 0; row < 10; row++)
        {
            Vector2 placePosition = new Vector2(row - 6, column * (-1) + 1);
            Quaternion q = new Quaternion();
            GameObject block;
            HitCube hitcube;
            LandMine landmine;
            int rnd = Random.Range(0, 20);
            if (rnd == 0)
            {
                block = Instantiate(mine, placePosition, q);
                landmine = block.AddComponent<LandMine>();
                landmine.bombcolumn = column;
                landmine.bombrow = row;
                landmine.BombGrid = BombGrid;
                BombGrid[column][row] = -1;
                //AroundSand(column, row);
            }
            else
            {
                block = Instantiate(sand, placePosition, q);
                hitcube = block.AddComponent<HitCube>();
                hitcube.cubecolumn = column;
                hitcube.cuberow = row;
                hitcube.Grid = Grid;
                hitcube.BombGrid = BombGrid;
            }
            Row.Add(block);
            block.transform.parent = blocksclone.transform;
            BombRow.Add(0);
            boolRow.Add(false);
        }
        Grid.Add(Row);
        BombGrid.Add(BombRow);
        boolsGrid.Add(boolRow);
        //Debug.Log(Grid.Count);
        if (Grid.Count > 15)
        {
            for (row = 0; row < 10; row++)
            {
                Destroy(Grid[0][row]);
            }
            Grid.RemoveAt(0);
            destroycolumn++;
        }

        for (row = 0; row < 10; row++)
        {
            if (BombGrid[column][row] == -1)
            {
                AroundSand(column, row);
            }
        }

        column++;
    }

    private void AroundSand(int column, int row)
    {
        //Debug.Log($"地雷処理　column:{column} row:{row}");
        for (int j = -1; j <= 1; j++)
        {
            for (int i = -1; i <= 1; i++)
            {
                if (row + j == -1 || row + j == 10)
                {
                    //Debug.Log("範囲外のためパス");
                    continue;
                }
                else
                {
                    if (j == 0 && i == 0 || BombGrid[column + i][row + j] == -1)
                    {
                        //Debug.Log("地雷・自身のためパス");
                        continue;
                    }
                    else
                    {
                        BombGrid[column + i][row + j]++;
                        //Debug.Log($"column:{column + i} row:{row + j} に追加");
                    }
                }
            }
        }
    }
    public void CreateFlags(int row, int column)
    {
        SpriteRenderer sr;
        sr = Grid[column - destroycolumn][row].GetComponent<SpriteRenderer>();
        if (sr.sprite.name == "Number_null")
        {
            sr.sprite = flag;
        }
        else if (sr.sprite.name == "Flag")
        {
            sr.sprite = nullblock;
        }
    }
}