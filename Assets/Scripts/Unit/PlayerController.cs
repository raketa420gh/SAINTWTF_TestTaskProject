using UnityEngine;
using Zenject;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private PlayerUnit _playerUnit;
    private IInputHandler _inputHandler;
    private bool _isControlsActive = true;

    [Inject]
    public void Construct(IInputHandler inputHandler)
    {
        _inputHandler = inputHandler;
    }

    private void Update()
    {
        if (!_isControlsActive) 
            return;
        
        var moveDirection = GetConvertedMoveDirection();
        
        if (moveDirection == Vector3.zero)
            return;

        _playerUnit.Movement.Move(moveDirection);
        
        var playerTransform = _playerUnit.transform;
        var playerPosition = playerTransform.position;
        playerTransform.forward = moveDirection;
        playerTransform.position  = new Vector3(playerPosition.x, 0, playerPosition.z);
    }

    private Vector3 GetConvertedMoveDirection()
    {
        return new Vector3(_inputHandler.MoveAxis.x, 0, _inputHandler.MoveAxis.y);
    }
}