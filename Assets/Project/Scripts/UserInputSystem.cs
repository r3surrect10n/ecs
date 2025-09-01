using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;


public class UserInputSystem : ComponentSystem
{
    private EntityQuery _inputQuery;

    private InputAction _moveAction;

    private float2 _moveInput;

    protected override void OnCreate()
    {
        _inputQuery = GetEntityQuery(ComponentType.ReadOnly<InputData>());
    }

    protected override void OnStartRunning()
    {
        _moveAction = new InputAction("move", binding: "<Gamepad>/leftStick");
        _moveAction.AddCompositeBinding("Dpad")
            .With("Up", binding: "<Keyboard>/w")
            .With("Left", binding: "<Keyboard>/a")
            .With("Down", binding: "<Keyboard>/s")
            .With("Right", binding: "<Keyboard>/d");

        _moveAction.performed += context => { _moveInput = context.ReadValue<Vector2>(); };
        _moveAction.started += context => { _moveInput = context.ReadValue<Vector2>(); };
        _moveAction.canceled += context => { _moveInput = context.ReadValue<Vector2>(); };
        _moveAction.Enable();
    }

    protected override void OnStopRunning()
    {
        _moveAction.Disable();
    }

    protected override void OnUpdate()
    {
        Entities.With(_inputQuery).ForEach(
            (Entity entity, ref InputData inputData) => { inputData.Move = _moveInput; });
    }
}
