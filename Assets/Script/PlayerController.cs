using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D rd;
    public Animator anim;
    public Collider2D coll;


    public float speed;         //�ٶȱ���
    public float JumpForce;     //��Ծ�ٶ�
    public LayerMask Ground;    //����ͼ��

    private bool CanJump = true;        //�����ж��ܷ���Ծ
    
    
    // Start is called before the first frame update
    void Start()
    {
        rd = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();   
        coll = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        SwitchAnimation();
    }

    void Movement()
    {
        float HorizontalSpeed = Input.GetAxis("Horizontal") * speed;        //������Time.deltaTime��������˲�ƣ�
        float FacedDirection = Input.GetAxisRaw("Horizontal");
        anim.SetFloat("running", Mathf.Abs(FacedDirection));
        if (FacedDirection != 0)                   //ˮƽ�ƶ�
        {
            rd.velocity = new Vector2(HorizontalSpeed, rd.velocity.y);
            if(HorizontalSpeed < 0)                         //��������ת��
            {
                transform.localScale = new Vector3(-1,1,1);
            }
            if (HorizontalSpeed > 0)                         //��������ת��
            {
                transform.localScale = new Vector3(1, 1, 1);
            }
        }
        else
        {
            rd.velocity = new Vector2(0,rd.velocity.y);
        }
        if(Input.GetButtonDown("Jump") && CanJump)                 //��Ծ
        {
            rd.velocity = new Vector2(rd.velocity.x,JumpForce);
            anim.SetBool("jumping",true);
            CanJump = false;
        }
    }
    void SwitchAnimation()
    {
        if(anim.GetBool("jumping"))
        {
                    if (rd.velocity.y < 0)                     //����
            {
                anim.SetBool("falling", true);
                anim.SetBool("jumping", false);
                CanJump = false;
            }
        }
        else if (coll.IsTouchingLayers(Ground))         //���
        {
            anim.SetBool("falling", false);
            anim.SetBool("idle", true);
            if (rd.velocity.y == 0)                      //�������������
            {
                CanJump = true;
            }
        }
    }
}
