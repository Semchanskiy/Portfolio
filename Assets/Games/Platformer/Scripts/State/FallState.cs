using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GamePlatformer
{
    public class FallState : State
    {
        private PlayerController _playerController; // �������������� ������

        public FallState(PlayerController playerController) // �����������
        {
            _playerController = playerController; // ����������� ���������� ������
        }

        public override void Enter()
        {
            base.Enter();
            _playerController.View._anim.CrossFade("Fall", 0);
        }

        public override void FixedUpdate()
        {
            _playerController.HorizontalMove();
            
            CheckState();
        }

        public override void Exit()
        {
            base.Exit();
        }

        public override void CheckState()
        {
            _playerController.CheckStateWalk();
            _playerController.CheckStateJump();
            _playerController.CheckStateIdle();
        }


    }
}
