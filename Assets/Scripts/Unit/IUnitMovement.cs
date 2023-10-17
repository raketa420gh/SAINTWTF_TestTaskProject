using UnityEngine;

public interface IUnitMovement
{
    void Initialize(float moveSpeed);
    void Move(Vector3 direction);
}