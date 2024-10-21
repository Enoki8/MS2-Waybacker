using UnityEngine;
public class SmoothDamp : MonoBehaviour
{
    public Vector2 target;
    [SerializeField] private float _smoothTime = 0.5f;
    [SerializeField] private float _maxSpeed = float.PositiveInfinity;
    private Vector2 _currentVelocity = Vector2.zero;
    public bool CompScroll = false;
    private void Update()
    {   

        Vector2 currentPos = Vector2.SmoothDamp
            (
                this.transform.position,
                target,
                ref _currentVelocity,
                _smoothTime,
                _maxSpeed
            );
        if (Mathf.Abs(this.transform.position.x - currentPos.x)<0.0001f)
        {
            this.transform.position = target;
            CompScroll = true;
        }
        else
        {
            this.transform.position = currentPos;
        }
    }
}