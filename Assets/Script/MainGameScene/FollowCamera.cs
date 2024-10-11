using UnityEngine;

[RequireComponent(typeof(Camera))]
public class FollowCamera : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] PlayerController Player;
    [SerializeField] ScoreManager scoreManager;
    [SerializeField] UIViewer viewer;
    public new GameObject camera;
    private Vector3 beforecamera;
    private Vector3 aftercamera;
    // Start is called before the first frame update
    void Start()
    {
        camera.transform.position = new Vector3(0, player.transform.position.y-1.0f, camera.transform.position.z);
    }
    // Update is called once per frame
    void LateUpdate()
    {
        beforecamera = transform.position;
        //Debug.Log($"player:{player.transform.position.y} camera:{camera.transform.position.y}");
        if (player.transform.position.y-1.0f<camera.transform.position.y)
        {
            camera.transform.position = new Vector3(camera.transform.position.x, player.transform.position.y - 1.0f, camera.transform.position.z);
        }
        ScrollUI();

    }

    private void ScrollUI()
    {
        aftercamera=(transform.position - beforecamera);
        {
            viewer.UICamera(aftercamera);
        }
    }
}
