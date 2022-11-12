using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_ExtraRun : PlayerState
{
    public Player_ExtraRun(PlayerControl player, PlayerStateMachine stateMachine, PlayerData playerData, string animationBoolName) : base(player, stateMachine, playerData, animationBoolName)
    {

    }

    public override void Checks()
    {
        base.Checks();
    }

    public override void Enter()
    {
        base.Enter();
        player.rb.gravityScale = 0;//����������Ϊ0
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        if (player.jumpCount > 0 && player.inputAction.JumpInput)//ʣ����Ծ���� �� ������Ծ��ʱ
        {
            stateMachine.ChangeState(player.JumpState);//������Ծ״̬
            player.jumpCount--;//��Ծ����-1
            player.rb.gravityScale = playerData.gravityMount;//������������
        }

        if(player.inputAction.MoveInput.x == 0||stateDuration>playerData.extraTime)
            //���ֹͣ�ƶ����� ����ʱ�䳬������ʱ��ʱ
        {
            stateMachine.ChangeState(player.FallState);
            player.rb.gravityScale = playerData.gravityMount;//������������
        }
    }

    public override void PhysicUpdate()
    {
        if (!player.isTouchWall()) player.SetVelocityX(playerData.moveSpeed * player.inputAction.MoveInput.x);//����ˮƽ�ƶ�
    }
}

