using System;
using Core.Inputs;
using UnityEngine;

namespace Core.Player
{
    public class PlayerInputs : MonoBehaviour
    {
        private GameplayInputActions _inputActions;

        private Action ShootAction;
        private Action JumpAction;

        public float HorizontalAxis { get => _horizontalAxis; }
        public Vector3 MouseWorldPosistion 
        { 
            get 
            {
                return Camera.main.ScreenToWorldPoint(_mouseWorldPosistion);
            } 
        }

        private float _horizontalAxis;
        private Vector3 _mouseWorldPosistion;

        private void Awake() => CacheComponents();

        private void CacheComponents()
        {
            _inputActions = new GameplayInputActions();
        }

        private void OnEnable() => EnableInputs();

        private void EnableInputs()
        {
            _inputActions.Enable();
        }

        private void OnDisable() => DisableInputs();

        private void DisableInputs()
        {
            UnsubscribeShootAction();
            UnsubscribeJumpAction();

            _inputActions.Disable();
        }

        private void Update() => ConstantInputs();

        private void ConstantInputs()
        {
            _horizontalAxis = _inputActions.Gameplay.Horizontal.ReadValue<float>();
            _mouseWorldPosistion = _inputActions.Gameplay.MousePosistion.ReadValue<Vector2>();
        }

        public void SubscribeShootAction(Action actionToPerform)
        {
            ShootAction += actionToPerform;

            _inputActions.Gameplay.Shoot.started += ctx => ShootAction();
        }

        public void UnsubscribeShootAction()
        {
            _inputActions.Gameplay.Shoot.started -= ctx => ShootAction();

            ShootAction = null;
        }

        public void SubscribeJumpAction(Action actionToPerform)
        {
            JumpAction += actionToPerform;

            _inputActions.Gameplay.Jump.started += ctx => JumpAction();
        }

        public void UnsubscribeJumpAction()
        {
            _inputActions.Gameplay.Jump.started -= ctx => JumpAction();

            JumpAction = null;
        }
    }
}
