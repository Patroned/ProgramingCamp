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
    public Player_ExtraRun ExtraMoveState { get; private set; }//�����ƶ�״̬
    public Player_Jump JumpState { get; private set; }//��Ծ״̬
    public Player_Fall FallState { get; private set; }//����״̬
    public Player_Land LandState { get; private set; }//���״̬

    public bool onGround = true;//�Ƿ�λ�ڵ�����
    public bool touchWall = false;//�Ƿ�Ӵ���ǽ��
    public bool canMove = true;//�Ƿ��ܹ��ƶ� 
    public int jumpCount = 0;//��ǰ��Ծ����

    private void Awake()
    {
        StateMachine = new PlayerStateMachine();
        IdleState = new Player_Idle(this, StateMachine, playerData, "idle");
        MoveState = new Player_Run(this, StateMachine, playerData, "run");
        JumpState = new Player_Jump(this, StateMachine, playerData, "jump");
        FallState = new Player_Fall(this, StateMachine, playerData, "fall");
        LandState = new Player_Land(this, StateMachine, playerData, "land");
        ExtraMoveState = new Player_ExtraRun(this, StateMachine, playerData, "extraJump");
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
        ani.SetBool("ground", isOnGround());//ͬ������״̬����������̨

        onGround = isOnGround();//����״̬
        touchWall = isTouchWall();//ǽ��Ӵ�״̬

        canMove = !touchWall;//�Ӵ���ǽ��ʱ�޷��ƶ�

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
    public bool isOnGround()//������
    {
        return Physics2D.OverlapCircle(groundCheckPos.position, playerData.groundCheckRadius, playerData.groundCheckLayer);
    }
    public Transform wallCheckPos;//������λ��
    public bool isTouchWall()//ǽ����
    {
        return Physics2D.OverlapBox(wallCheckPos.position, playerData.wallCheckRange,0 ,playerData.wallCheckLayer);
    }
}

