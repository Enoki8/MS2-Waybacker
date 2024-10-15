using UnityEngine;

/// <summary>
/// ターゲットのx座標に追従させるスクリプト
/// </summary>
public class SmoothDamp : MonoBehaviour
{
    public Vector2 target;
    // 目標値に到達するまでのおおよその時間[s]
    [SerializeField] private float _smoothTime = 0.5f;

    // 最高速度
    [SerializeField] private float _maxSpeed = float.PositiveInfinity;

    // 現在速度(SmoothDampの計算のために必要)
    private Vector2 _currentVelocity = Vector2.zero;

    // x座標をターゲットのx座標に追従させる
    private void Update()
    {
        // 現在位置取得
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