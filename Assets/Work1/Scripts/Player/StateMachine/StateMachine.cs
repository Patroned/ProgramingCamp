using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateMachine
{
    public PlayerState CurrentState { get; private set; }

    public void Initialize(PlayerState stratState)//��ʼ��״̬
    {
        CurrentState = stratState;//����ǰ״̬����Ϊ��ʼ״̬
        CurrentState.Enter();//�����ʼ״̬
    }

    public void ChangeState(PlayerState nextState)//�л�״̬
    {
        CurrentState.Exit();//�˳���ǰ״̬
        CurrentState = nextState;//����ǰ״̬����Ϊ��һ״̬
        CurrentState.Enter();//������һ״̬
    }
}
