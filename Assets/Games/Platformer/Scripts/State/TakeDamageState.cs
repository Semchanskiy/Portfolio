using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;

namespace GamePlatformer
{
    public class TakeDamageState : State
    {
        private PlayerController _playerController; // инициализируем игрока

        public TakeDamageState(PlayerController playerController)
        {
            _playerController = playerController; // присваиваем переменной игрока
        }

        public override void Enter()
        {
            _playerController._input.Disable();
            _playerController.Model.lives--;
            _playerController.Model._isVulnerability = false;
            _playerController.View._anim.CrossFade("TakeDamage", 0);
        }

        public override void FixedUpdate()
        {

        }

        public override void Exit()
        {
            _playerController._input.Enable();
        }

        public override void CheckState()
        {
            _playerController.CheckStateWalk();
            _playerController.CheckStateFall();
            _playerController.CheckStateJump();
        }
    }
}
