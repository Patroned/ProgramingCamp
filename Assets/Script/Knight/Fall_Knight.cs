using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fall_Knight : State
{
    private FSM_Knight fsm;
    public Fall_Knight(FSM_Knight fsm)
    {
        this.fsm = fsm;
    }

    public override void OnEnter()
    {
        fsm.anim.SetBool("isFalling",true);
    }

    public override void OnExit()
    {
        fsm.anim.SetBool("isFalling", false);
    }

    public override void OnUpdate()
    {
        fsm.Move();

        //������������棬���л�ΪIdle״̬
        if (fsm.coll.IsTouchingLayers(fsm.ground))
        {
            fsm.ChangeState(StateType.Idle);
        }
    }
}
