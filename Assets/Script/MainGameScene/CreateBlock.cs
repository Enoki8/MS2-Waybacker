using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
public class CreateBlock : MonoBehaviour
{
    [SerializeField] ScoreManager scoreManager;
    [SerializeField] Director director;

    [SerializeField] GameObject sand;
    [SerializeField] GameObject mine;
    [SerializeField] GameObject blocksclone;


    public Sprite[] hints;
    public Sprite flag;
    public Sprite bomb;
    public Sprite nullblock;
    public Sprite null2;
    
    [SerializeField] private int baseChance;
    [SerializeField] private int afterChance;
    [SerializeField] private int worstChance;

    public List<List<GameObject>> Grid = new List<List<GameObject>>();
    public List<List<int>> BombGrid = new List<List<int>>();
    public List<List<bool>> boolsGrid = new List<List<bool>>();
    public int destroycolumn = 0;
    public int column = 0;
    public int row = 0;
    private bool beforebomb = false;
    private int createdbomb = 0;
    private int waitedtime = 0;
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
                    scoreManager.ScoreUp((zokusei * zokusei) * 100);
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
            block = Instantiate(sand, placePosition, q);
            BombRow.Add(0);

            CreateBomb(column, row);

            Row.Add(block);
            block.transform.parent = blocksclone.transform;
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

    private void CreateBomb(int column, int row)
    {
        if (waitedtime == 0)
        {
            if (Grid.Count > 4)
            {
                int rnd;
                if (beforebomb)
                {
                    rnd = Random.Range(0, worstChance);
                }
                else
                {
                    afterChance = Mathf.Max(worstChance,(int)(baseChance - (((30 + scoreManager.GameSteps) / 30)) + 1));
                    rnd = Random.Range(0, afterChance);

                }
                if (rnd == 0)
                {
                    //Debug.Log(createdbomb);
                    BombGrid[column][row] = -1;
                    beforebomb = true;
                    createdbomb++;
                    if (createdbomb > 6+Random.Range(0,3))
                    {
                        createdbomb = 0;
                        waitedtime = 11+Random.Range(0,10);
                    }
                    //AroundSand(column, row);
                }
                else
                {
                    beforebomb = false;
                }

            }
        }
        else
        {
            waitedtime--;
        }
    }



    public void CreateFlags(int row, int column)
    {
        if (Grid[column - destroycolumn][row] != null)
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
}