using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Run : PlayerState
{
    public Player_Run(PlayerControl player, PlayerStateMachine stateMachine, PlayerData playerData, string animationBoolName) : base(player, stateMachine, playerData, animationBoolName)
    {

    }

    public override void Checks()
    {
        base.Checks();
    }

    public override void Enter()
    {
        base.Enter();

    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if (player.inputAction.MoveInput.x == 0&&player.onGround)//λ�ڵ��� �� �������ƶ�����ʱ 
        {
            stateMachine.ChangeState(player.IdleState);//�������״̬
        }

        if (player.isOnGround() == false)//�뿪����ʱ
        {
            stateMachine.ChangeState(player.ExtraMoveState);//��������ƶ�״̬
        }

        if (player.inputAction.JumpInput&&player.jumpCount>0)//ʣ����Ծ���� �� ��Ծ�������ʱ 
        {
            stateMachine.ChangeState(player.JumpState);//������Ծ״̬
        }

    }

    public override void PhysicUpdate()
    {
        if (player.canMove)//�ܹ��ƶ�ʱ 
        {
            player.SetVelocityX(playerData.moveSpeed * player.inputAction.MoveInput.x);//���п��������ƶ�
            player.transform.localScale = new Vector2(((player.inputAction.MoveInput.x > 0) ? 1 : -1), 1);//���÷�ת����
            player.ani.SetFloat("speedY", Mathf.Abs(0.6f));//����ͬ������״̬
        }
    }
}
