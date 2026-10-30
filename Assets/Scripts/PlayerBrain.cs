using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerBrain : MonoBehaviour
{
    [SerializeField] private EntityMovement _movement;
    [SerializeField] private EntityAttack _attack;
    public InputActionReference _moveInput;
    public InputActionReference _AttackInput;
    private Vector3 _direction;

    public event Action Order;

    void Start()
    {
        _moveInput.action.started += ComputeDirection;
        _moveInput.action.canceled += ComputeDirection;
        _moveInput.action.performed += ComputeDirection;
        _AttackInput.action.started += ComputeAttack;
        _AttackInput.action.canceled += ComputeAttack;
    }

    void ComputeDirection(InputAction.CallbackContext context)
    {
        if (context.started || context.performed)
        {
            _direction = new Vector3(_moveInput.action.ReadValue<Vector2>().x, 0, _moveInput.action.ReadValue<Vector2>().y);
        }else
        {
            _direction = new Vector3(0, 0, 0);
        }
        _movement.UpdateDirection(_direction);
    }

    void ComputeAttack(InputAction.CallbackContext context)
    {
        if (context.started) {
            _attack.Attack(true);
        }else
        {
            _attack.Attack(false);
        }
    }

    private void OnDestroy()
    {
        _moveInput.action.started -= ComputeDirection;
        _moveInput.action.canceled -= ComputeDirection;
        _moveInput.action.performed -= ComputeDirection;
    }
}
