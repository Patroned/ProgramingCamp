using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Jump : PlayerState
{
    public Player_Jump(PlayerControl player, PlayerStateMachine stateMachine, PlayerData playerData, string animationBoolName) : base(player, stateMachine, playerData, animationBoolName)
    {

    }

    public override void Checks()
    {
        base.Checks();
    }

    public override void Enter()
    {
        base.Enter();
        player.SetVelocityY(playerData.jumpForce);//��ȡ��Ծ�������� ������Ծ
    }

    public override void Exit()
    {
        base.Exit();
        player.SetVelocityY(0);//������y���ٶȹ���
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if (player.rb.velocity.y < 0 && !player.isOnGround()) //������y���ٶ�С��0 �Ҳ�λ�ڵ���
            stateMachine.ChangeState(player.FallState);//���������״̬

        if(!player.inputAction.JumpInput) //��ֹͣ������Ծ
            stateMachine.ChangeState(player.FallState);//���������״̬

        player.ani.SetFloat("speedY", Mathf.Abs(0.4f));//����ͬ������״̬
    }

    public override void PhysicUpdate()
    {

    }
}