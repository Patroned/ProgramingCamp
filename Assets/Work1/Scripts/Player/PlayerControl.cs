using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public Animator ani { get; private set; }//��Ҷ���
    public Rigidbody2D rb { get; private set; }//��Ҹ���
    public PlayerStateMachine StateMachine { get; private set; }//���״̬��
    public PlayerInputAction inputAction { get; private set; }//��������¼�
    public PlayerData playerData;//�������

    public Player_Idle IdleState { get; private set; }//����״̬
    public Player_Run MoveState { get; private set; }//�ƶ�״̬
    public Player_Jump JumpState { get; private set; }//��Ծ״̬
    public Player_Fall FallState { get; private set; }//����״̬
    public Player_Land LandState { get; private set; }//���״̬

    private void Awake()
    {
        StateMachine = new PlayerStateMachine();
        IdleState = new Player_Idle(this, StateMachine, playerData, "idle");
        MoveState = new Player_Run(this, StateMachine, playerData, "run");
        JumpState = new Player_Jump(this, StateMachine, playerData, "jump");
        FallState = new Player_Fall(this, StateMachine, playerData, "fall");
        LandState = new Player_Land(this, StateMachine, playerData, "land");
    }

    private void Start()
    {
        ani = GetComponent<Animator>();//��ȡ�������
        rb = GetComponent<Rigidbody2D>();//��ȡ�������
        inputAction = GetComponent<PlayerInputAction>();
        StateMachine.Initialize(IdleState);//��ʼ��ΪIdle״̬
    }
    public void Update()
    {
        StateMachine.CurrentState.LogicUpdate();
        ani.SetBool("ground", isOnGround());
    }
    public void FixedUpdate()
    {
        StateMachine.CurrentState.PhysicUpdate();
    }



    public void SetVelocityX(float velocityX)//����x���ٶ�
    {
        rb.velocity = new Vector2(velocityX, rb.velocity.y);
    }

    public void SetVelocityY(float velocityY)//����y���ٶ�
    {
        rb.velocity = new Vector2(rb.velocity.x, velocityY);
    }

    public Transform groundCheckPos;//������λ��
    public bool isOnGround()//���е�����
    {
        return Physics2D.OverlapCircle(groundCheckPos.position, playerData.groundCheckRadius, playerData.groundCheckLayer);
    }

    public Transform wallCheckPos;//������λ��
    public bool isTouchWall()//����ǽ����
    {
        return Physics2D.OverlapBox(wallCheckPos.position, playerData.wallCheckRange,0 ,playerData.wallCheckLayer);
    }
}

