using System.Collections.Generic;
using UnityEngine;

public class NameEntry : MonoBehaviour
{
    [SerializeField] List<GameObject> Alps;
    [SerializeField] KeyAttach KeyAttach;
    [SerializeField] FontStore FontStore;
    [SerializeField] int position = 0;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        int button = KeyAttach.Pushed();
        if (button != 0)
        {
            ViewAlps(Posset());
        }
    }
    private int[] Posset()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            position = position - 1;
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            position = position + 1;
            if (position > 26)
            {
                position = 0;
            }
        }
        position = Replace(position);

        int[] alps = new int[5];
        for (int i = 0; i < alps.Length; i++)
        {
            alps[i] = Replace(position + (i - 2));
        }
        return alps;
    }

    private int Replace(int num)
    {
        if (num < 0)
        {
            num = 26 + (num + 1);
        }
        else if (num > 26)
        {
            num = 0 + (num - 27);
        }
        return num;
    }
    private void ViewAlps(int[] alps)
    {
        for (int i = 0; i < alps.Length; i++)
        {
            Debug.Log(alps[i]);
            SpriteRenderer sr;
            sr = Alps[i].GetComponent<SpriteRenderer>();
            sr.sprite = FontStore.fonts[alps[i]];
        }
    }
}
