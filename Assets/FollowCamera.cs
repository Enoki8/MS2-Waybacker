using UnityEngine;

[RequireComponent(typeof(Camera))]
public class FollowCamera : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] Player Player;
    public new GameObject camera;
    // Start is called before the first frame update
    void Start()
    {
        
        camera.transform.position = new Vector3(6.0f, player.transform.position.y-1.0f, camera.transform.position.z);
    }
    // Update is called once per frame
    void LateUpdate()
    {
        if (Player.uplimit == 0)
        {
            camera.transform.position = new Vector3(camera.transform.position.x, player.transform.position.y - 1.0f, camera.transform.position.z);
        }
    }
}
