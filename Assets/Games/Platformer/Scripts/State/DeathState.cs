using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;

namespace GamePlatformer
{
    public class DeathState : State
    {
        private PlayerController _playerController; // инициализируем игрока

        public DeathState(PlayerController playerController)
        {
            _playerController = playerController; // присваиваем переменной игрока
        }

        public override void Enter()
        {
            _playerController._input.Disable();
            _playerController.View._anim.CrossFade("Death", 0);
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
            
        }
    }
}
