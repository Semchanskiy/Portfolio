using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : State
{
    private PlatformerPlayer _player; // �������������� ������

    public IdleState(PlatformerPlayer player) // �����������
    {
        _player = player; // ����������� ���������� ������
    }

    public override void Enter()
    {
        base.Enter();
        _player._anim.SetBool("Idle", true);
    }


    public override void Exit()
    {
        _player._anim.SetBool("Idle", false);
        base.Exit();
    }
}
