using UnityEngine;
public class SmoothDamp : MonoBehaviour
{
    public Vector2 target;
    [SerializeField] private float _smoothTime = 0.5f;
    [SerializeField] private float _maxSpeed = float.PositiveInfinity;
    private Vector2 _currentVelocity = Vector2.zero;
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
        this.transform.position = currentPos;
    }
}