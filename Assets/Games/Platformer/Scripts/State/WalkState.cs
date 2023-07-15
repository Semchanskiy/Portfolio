using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkState : State
{
    private PlatformerPlayer _player; // �������������� ������

    public WalkState(PlatformerPlayer player) // �����������
    {
        _player = player; // ����������� ���������� ������
    }

    public override void Enter()
    {
        base.Enter();
        _player._anim.SetBool("Walk", true);
    }

    public override void FixedUpdate()
    {
        base.FixedUpdate();
        

    }

    public override void Exit()
    {
        _player._anim.SetBool("Walk", false);
        base.Exit();
    }
}
