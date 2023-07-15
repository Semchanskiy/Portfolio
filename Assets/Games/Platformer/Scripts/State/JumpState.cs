using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpState : State
{
    private PlatformerPlayer _player; // инициализируем игрока

    public JumpState(PlatformerPlayer player) // конструктор
    {
        _player = player; // присваиваем переменной игрока
    }

    public override void Enter()
    {
        base.Enter();
        _player.Jump();
        _player._anim.SetBool("Jump", true);
    }

    public override void FixedUpdate()
    {
        base.FixedUpdate();

    }

    public override void Exit()
    {
        _player._anim.SetBool("Jump", false);
        base.Exit();
    }
}
