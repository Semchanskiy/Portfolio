using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GamePlatformer
{
    public class JumpState : State
    {
        private PlayerController _playerController; // �������������� ������

        public JumpState(PlayerController playerController) // �����������
        {
            _playerController = playerController; // ����������� ���������� ������
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
