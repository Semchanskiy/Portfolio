using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.EventSystems.StandaloneInputModule;
using UnityEngine.Windows;

namespace GamePlatformer
{
    public class WalkState : State
    {
        private PlayerController _playerController; // �������������� ������

        public WalkState(PlayerController playerController) // �����������
        {
            _playerController = playerController; // ����������� ���������� ������
        }

        public override void Enter()
        {
            base.Enter();
            _playerController.View._anim.CrossFade("Walk", 0);
        }

        public override void FixedUpdate()
        {
            _playerController.HorizontalMove();
            CheckState();
        }



        public override void CheckState()
        {
            _playerController.CheckStateFall();
            _playerController.CheckStateJump();
            _playerController.CheckStateIdle();
        }





        public override void Exit()
        {
            base.Exit();
        }
    }
}
