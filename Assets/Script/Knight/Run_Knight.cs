using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Run_Knight : State
{
    private FSM_Knight fsm;
    public Run_Knight(FSM_Knight fSM)
    {
        this.fsm = fSM;
    }
    public override void OnEnter()
    {
        fsm.anim.SetBool("isRunning", true);
    }

    public override void OnExit()
    {
        fsm.anim.SetBool("isRunning", false);
    }

    public override void OnUpdate()
    {
        float move = fsm.Move();

        //����ٶ����������ͱ��Idle״̬
        if (Mathf.Abs(move) < 0.05f)
        {
            fsm.ChangeState(StateType.Idle);
        }

        //����ո��£����л���Jump״̬
        if (fsm.spacePress)
        {
            fsm.ChangeState(StateType.Jump);
            fsm.spacePress = false;
        }
    }
}
