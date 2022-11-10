using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump_Knight : State
{
    private FSM_Knight fsm;
    public Jump_Knight(FSM_Knight fsm)
    {
        this.fsm = fsm;
    }

    public override void OnEnter()
    {
        fsm.anim.SetBool("isJumping", true);
        //����Jump״̬ʱ��Ծ
        fsm.rb.AddForce(new Vector2(0, fsm.jumpForce));
    }

    public override void OnExit()
    {
        fsm.anim.SetBool("isJumping", false);
    }

    public override void OnUpdate()
    {
        fsm.Move();

        //�����ֱ�ٶ�С��0��˵���������䣬�л���Fall״̬
        if (fsm.rb.velocity.y < 0) 
            fsm.ChangeState(StateType.Fall);
    }
}
