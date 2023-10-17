using UnityEngine;

public class JoystickInputHandler : MonoBehaviour, IInputHandler
{
    [SerializeField] private Joystick _joystick;

    public Vector2 MoveAxis => _joystick.Direction;
}