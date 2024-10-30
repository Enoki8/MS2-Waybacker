using UnityEngine;

public class KeyAttach : MonoBehaviour
{
    public int Pushed()
    {
        if ((Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.A)) ||
            (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.S)))
        {
            return 0;
        }

        if (Input.GetKey(KeyCode.D)) return 1;
        if (Input.GetKey(KeyCode.A)) return 2;
        if (Input.GetKey(KeyCode.S)) return 3;
        if (Input.GetKey(KeyCode.W)) return 4;

        return 0;
    }

    public int PushedDown()
    {
        if ((Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.A)) ||
            (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.S)))
        {
            return 0;
        }

        if (Input.GetKeyDown(KeyCode.D)) return 1;
        if (Input.GetKeyDown(KeyCode.A)) return 2;
        if (Input.GetKeyDown(KeyCode.S)) return 3;
        if (Input.GetKeyDown(KeyCode.W)) return 4;

        return 0;
    }

    public bool RetrurnKey(string key)
    {
        if (key == "A")
        {
            if (Input.GetKey(KeyCode.P))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        if ((key == "B"))
        {
            if (Input.GetKey(KeyCode.O))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        return false;
    }
    public bool RetrurnKeyDown(string key)
    {
        if (key == "A")
        {
            if (Input.GetKeyDown(KeyCode.P))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        if ((key == "B"))
        {
            if (Input.GetKeyDown(KeyCode.O))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        return false;
    }
}
