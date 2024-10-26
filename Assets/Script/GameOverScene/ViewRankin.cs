using UnityEngine;

public class ViewRankin : MonoBehaviour
{
    public void SetChildrenActive(bool isActive)
    {
        foreach (Transform child in transform)
        {
            child.gameObject.SetActive(isActive);
        }
    }
}