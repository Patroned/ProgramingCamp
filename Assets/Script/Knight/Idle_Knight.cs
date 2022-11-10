using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Idle_Knight : State
{
    private FSM_Knight fsm;
    public Idle_Knight(FSM_Knight fSM)
    {
        this.fsm = fSM;
    }

    public override void OnEnter()
    {
        fsm.anim.SetBool("isIdling", true);
        //�����Ծʱ���µĿո�
        fsm.spacePress = false;
    }

    public override void OnExit()
    {
        fsm.anim.SetBool("isIdling", false);
    }

    public override void OnUpdate()
    {
        //�����ɫ����ˮƽ�ƶ������л���Run״̬
        if (fsm.Move() != 0) 
        {
            fsm.ChangeState(StateType.Run);
        }

        //����ո��£����л���Jump״̬
        if (fsm.spacePress)
        {
            fsm.ChangeState(StateType.Jump);
            fsm.spacePress = false;
        }
    }
}
