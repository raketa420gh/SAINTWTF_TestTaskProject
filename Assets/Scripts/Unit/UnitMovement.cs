using UnityEngine;

[RequireComponent(typeof(CharacterController))]

public class UnitMovement : MonoBehaviour, IUnitMovement
{
    private float _moveSpeed;

    private CharacterController _characterController;

    public void Initialize(float moveSpeed)
    { 
        _characterController = GetComponent<CharacterController>();
        _moveSpeed = moveSpeed;
    }

    public void Move(Vector3 direction)
    {
        _characterController.Move(direction * (Time.deltaTime * _moveSpeed));
    }
}