using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GamePlatformer
{
    public class JumpState : State
    {
        private PlayerController _playerController; // инициализируем игрока

        public JumpState(PlayerController playerController) // конструктор
        {
            _playerController = playerController; // присваиваем переменной игрока
        }

        public override void Enter()
        {
            if (_playerController._input.Player.Jump.triggered)
            {
                _playerController.View._soundJump.Play();
            }
            _playerController.View._anim.CrossFade("Jump", 0);
        }

        public override void FixedUpdate()
        {
            _playerController.HorizontalMove();
            CheckState();
        }

        public override void Exit()
        {

        }

        public override void CheckState()
        {
            _playerController.CheckStateWalk();
            _playerController.CheckStateFall();
            _playerController.CheckStateIdle();
        }
    }
}
