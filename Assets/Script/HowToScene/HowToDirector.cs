using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HowToDirector : MonoBehaviour
{
    [SerializeField] List<GameObject> HowToObject;
    [SerializeField] Shade Shading;

    [SerializeField] GameObject PushA;
    // Start is called before the first frame update
    void Start()
    {
        if (!StaticList.ingame)
        {
            PushA.SetActive(true);

        }
        StartCoroutine(StartHowto());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator StartHowto()
    {
        yield return new WaitForSeconds(1f);
        SetActiveObject(0, true);
        yield return new WaitForSeconds(10f);
        SetActiveObject(0, false);
        yield return new WaitForSeconds(1f);
        SetActiveObject(1, true);
        yield return new WaitForSeconds(8f);
        SetActiveObject(1, false);
        yield return new WaitForSeconds(1f);
        SetActiveObject(2, true);
        yield return new WaitForSeconds(5f);
        SetActiveObject(2, false);
        yield return new WaitForSeconds(1f);
        SetActiveObject(3, true);
        yield return new WaitForSeconds(15f);
        SetActiveObject(3, false);
        yield return new WaitForSeconds(2f);
        Shading.demoended = true;
    }

    public void SetActiveObject(int Object,bool get)
    {
        GameObject gameObject = HowToObject[Object];
        gameObject.SetActive(get);
    }
}
