using System;
using GameInput;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputProvider
{
    private InputActions _input = new();

    public event Action<InputAction.CallbackContext> ShootPerformed
    {
        add
        {
            _input.Player.Attack.performed += value;
        }
        remove
        {
            _input.Player.Attack.performed -= value;
        }
    }
    public Vector2 MovementInput()
    {
        return _input.Player.Walk.ReadValue<Vector2>();
    }
    
    ///public 
}
