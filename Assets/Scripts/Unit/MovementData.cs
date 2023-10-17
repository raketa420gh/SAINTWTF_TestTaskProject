using UnityEngine;

[CreateAssetMenu(order = 54, menuName = "MovementData", fileName = "MovementData")]

public class MovementData : ScriptableObject
{
    [SerializeField] private float _moveSpeed = 3f;

    public float MoveSpeed => _moveSpeed;
}