using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;

namespace GamePlatformer
{
    public class IdleState : State
    {
        private PlayerController _playerController; // �������������� ������

        public IdleState(PlayerController playerController)
        {
            _playerController = playerController; // ����������� ���������� ������
        }

        public override void Enter()
        {
            _playerController.View._anim.CrossFade("Idle", 0);
        }

        public override void FixedUpdate()
        {
            CheckState();
        }

        public override void Exit()
        {

        }

        public override void CheckState()
        {
            _playerController.CheckStateWalk();
            _playerController.CheckStateFall();
            _playerController.CheckStateJump();
        }
    }
}
