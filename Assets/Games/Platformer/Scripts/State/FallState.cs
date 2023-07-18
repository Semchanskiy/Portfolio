using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallState : State
{
    private PlatformerPlayer _player; // �������������� ������

    public FallState(PlatformerPlayer player) // �����������
    {
        _player = player; // ����������� ���������� ������
    }

    public override void Enter()
    {
        base.Enter();
        _player._anim.SetBool("Fall", true);
    }
    public override void Exit()
    {
        _player._anim.SetBool("Fall", false);
        base.Exit();
    }
}
