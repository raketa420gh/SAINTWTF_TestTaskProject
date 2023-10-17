using UnityEngine;

public class CameraFollower : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private Transform _followTarget;
    private bool _isActive = true;
    private Vector3 _targetPositionOffset;

    private void Awake()
    {
        _targetPositionOffset = _camera.transform.position - _followTarget.transform.position;
    }

    private void LateUpdate()
    {
        if (!_isActive)
            return;
        
        _camera.transform.position = _followTarget.transform.position + _targetPositionOffset;
    }
}
