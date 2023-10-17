using UnityEngine;

[RequireComponent(typeof(UnitMovement))]

public abstract class MovableUnit : MonoBehaviour, IMovableUnit
{
    [SerializeField] private MovementData _movementData;
    private IUnitMovement _movement;

    public Transform Transform => transform;
    public IUnitMovement Movement => _movement;

    protected virtual void Awake()
    {
        _movement = GetComponent<IUnitMovement>();
        _movement.Initialize(_movementData.MoveSpeed);
    }
}