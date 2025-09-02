using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;


public class UserInputSystem : ComponentSystem
{
    private EntityQuery _inputQuery;

    private InputAction _moveAction;
    private InputAction _shootAction;
    private InputAction _rushAction;

    private float2 _moveInput;
    private float _shootInput;
    private float _rushInput;

    protected override void OnCreate()
    {
        _inputQuery = GetEntityQuery(ComponentType.ReadOnly<InputData>());
    }

    protected override void OnStartRunning()
    {
        #region MoveAction
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
        #endregion

        #region ShootAction
        _shootAction = new InputAction("shoot", binding: "<Keyboard>/space");        
        _shootAction.performed += context => { _shootInput = context.ReadValue<float>(); };
        _shootAction.started += context => { _shootInput = context.ReadValue<float>(); };
        _shootAction.canceled += context => { _shootInput = context.ReadValue<float>(); };
        _shootAction.Enable();
        #endregion

        #region ShootAction
        _rushAction = new InputAction("shoot", binding: "<Keyboard>/tab");
        _rushAction.performed += context => { _rushInput = context.ReadValue<float>(); };
        _rushAction.started += context => { _rushInput = context.ReadValue<float>(); };
        _rushAction.canceled += context => { _rushInput = context.ReadValue<float>(); };
        _rushAction.Enable();
        #endregion

    }

    protected override void OnStopRunning()
    {
        _moveAction.Disable();
        _shootAction.Disable();
        _rushAction.Disable();
    }

    protected override void OnUpdate()
    {
        Entities.With(_inputQuery).ForEach(
            (Entity entity, ref InputData inputData) => 
            { 
                inputData.Move = _moveInput; 
                inputData.Shoot = _shootInput;
            });
    }
}
