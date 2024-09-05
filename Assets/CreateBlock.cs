using System.Collections.Generic;
using UnityEngine;
public class CreateBlock : MonoBehaviour
{
    [SerializeField] GameObject sand;
    [SerializeField] GameObject mine;
    [SerializeField] Player player;
    public Sprite hint1;
    public Sprite hint2;
    public Sprite hint3;
    public Sprite hint4;
    public Sprite hint5;
    public Sprite hint6;
    public Sprite hint7;
    public Sprite hint8;
    public Sprite hint9;
    public Sprite bomb;
    public Sprite n;

    List<List<GameObject>> Grid = new List<List<GameObject>>();
    List<List<int>> BombGrid = new List<List<int>>();

    public int destroycolumn = 0;
    public int column = 0;
    public int row = 0;
    // Start is called before the first frame update
    void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {

        //Debug.Log($"gridcount:{Grid.Count} bombgrid:{BombGrid.Count}");
    }
    public void Destroyblock(int column, int row)//ブロック壊す
    {
        int zokusei = BombGrid[column][row];
        //Debug.Log($"zokusei:{zokusei}");
        if (zokusei == 0)
        {
            //Destroy(Grid[column - destroycolumn][row]);
            SpriteRenderer sr;
            sr = Grid[column - destroycolumn][row].GetComponent<SpriteRenderer>();
            sr.sprite = n;
        }
        else
        {
            //Debug.Log("画像変更");
            SpriteRenderer sr;
            sr = Grid[column - destroycolumn][row].GetComponent<SpriteRenderer>();
            if (zokusei == -1)
            {
                sr.sprite = bomb;
                Debug.Log("GameOver!!");
            }
            if (zokusei == 1)
            {
                sr.sprite = hint1;
            }
            if (zokusei == 2)
            {
                sr.sprite = hint2;
            }
            if (zokusei == 3)
            {
                sr.sprite = hint3;
            }
        }

    }


    public void Createnull()
    {
        List<GameObject> Row = new List<GameObject>();
        List<int> BombRow = new List<int>();
        for (row = 0; row < 10; row++)
        {
            Row.Add(null);
            BombRow.Add(0);
        }
        Grid.Add(Row);
        BombGrid.Add(BombRow);
        BombGrid.Add(BombRow);
        column++;
    }


    public void Createrow()//ブロック作る
    {
        List<GameObject> Row = new List<GameObject>();
        List<int> BombRow = new List<int>();
        for (row = 0; row < 10; row++)
        {
            Vector2 placePosition = new Vector2(row, column * (-1));
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
            BombRow.Add(0);
        }
        Grid.Add(Row);
        BombGrid.Add(BombRow);

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
}