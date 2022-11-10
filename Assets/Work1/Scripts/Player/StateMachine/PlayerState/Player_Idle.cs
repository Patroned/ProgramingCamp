using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Idle : PlayerState
{
    public Player_Idle(PlayerControl player, PlayerStateMachine stateMachine, PlayerData playerData, string animationBoolName) : base(player, stateMachine, playerData, animationBoolName)
    {

    }

    public override void Checks()
    {
        base.Checks();
    }

    public override void Enter()
    {
        base.Enter();
        player.SetVelocityX(0);
    }

    public override void Exit()
    {
        base.Exit();
        player.transform.localScale = new Vector2(((player.inputAction.MoveInput.x > 0) ? 1 : -1), 1);//���÷�ת����
    }

    public override void LogicUpdate()//������״̬:�ƶ� ��Ծ
    {
        base.LogicUpdate();
        if (player.inputAction.MoveInput.x != 0)//�ƶ��������ʱ �����ƶ�״̬
        {
            stateMachine.ChangeState(player.MoveState);
        }

        if (player.inputAction.JumpInput)//��Ծ�������ʱ ������Ծ״̬
        {
            stateMachine.ChangeState(player.JumpState);
        }
    }

    public override void PhysicUpdate()
    {
        base.PhysicUpdate();
    }
}
