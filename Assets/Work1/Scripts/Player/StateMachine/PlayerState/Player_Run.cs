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
        if (player.inputAction.MoveInput.x == 0)//�������ƶ�����ʱ �������״̬
        {
            stateMachine.ChangeState(player.IdleState);
        }
        if (player.inputAction.JumpInput)//��Ծ�������ʱ ������Ծ״̬
        {
            stateMachine.ChangeState(player.JumpState);
        }

    }

    public override void PhysicUpdate()
    {
       if(!player.isTouchWall()) player.SetVelocityX(playerData.moveSpeed * player.inputAction.MoveInput.x);//����ˮƽ�ƶ�
    }
}
