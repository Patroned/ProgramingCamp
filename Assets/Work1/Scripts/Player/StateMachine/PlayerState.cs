using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState
{
    protected PlayerControl player;//��ҿ���
    protected PlayerStateMachine stateMachine;//���״̬��
    protected PlayerData playerData;//�������

    private float stateStartTime;//������ʼʱ��
    private string animationBoolName;//���Ŷ�����

    public PlayerState(PlayerControl player, PlayerStateMachine stateMachine, PlayerData playerData, string animationBoolName)
    {
        this.player = player;
        this.stateMachine = stateMachine;
        this.playerData = playerData;
        this.animationBoolName = animationBoolName;
    }

    public virtual void Enter()//����״̬ʱ
    {
        Checks();
        stateStartTime = Time.time;//��¼״̬����ʱ��
        player.ani.SetBool(animationBoolName, true);//��״̬����Ӧbool��������Ϊtrue
    }

    public virtual void Exit()//�˳�״̬ʱ
    {
        player.ani.SetBool(animationBoolName, false);//��״̬����Ӧbool��������Ϊtrue
    }

    public virtual void LogicUpdate()//�߼�����
    {

    }

    public virtual void PhysicUpdate()//�������
    {

    }

    public virtual void Checks()//���
    {

    }
}
