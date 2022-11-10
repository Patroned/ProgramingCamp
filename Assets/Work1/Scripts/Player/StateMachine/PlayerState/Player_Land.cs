using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Land : PlayerState
{
    public Player_Land(PlayerControl player, PlayerStateMachine stateMachine, PlayerData playerData, string animationBoolName) : base(player, stateMachine, playerData, animationBoolName)
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
        if (player.isOnGround())
        {
            stateMachine.ChangeState(player.IdleState);
        }

    }

    public override void PhysicUpdate()
    {

    }
}
