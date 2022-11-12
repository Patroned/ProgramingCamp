using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playcontrol : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    public Collider2D coll;
    public float speed;
    public float jumpfore;
    public LayerMask ground;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()   
    {
        Movement();
        SwitchAnim();

    }

    void Movement()  //Movement Ϊ�Զ��� ����
    {
        float Horizontalmove = Input.GetAxis("Horizontal");// Horizontal ֻ���������� 1���� -1���� 0����;
        float facedirection = Input.GetAxisRaw("Horizontal");//GetAxisRaw �� GetAxis ��һ������ ����ֱ�ӻ�ȡ 1 -1 0

        #region ��ɫ�ƶ�
        if (Horizontalmove != 0)
        {
            //�ø������ı��ٶ� velocity�ٶȵı仯    //vector2 2Dƽ̨�� X Y �����ƶ��ı仯
            rb.velocity = new Vector2(Horizontalmove * speed , rb.velocity.y);
            //Time.deltaTime ����ʱ�ӵ����аٷֱ�   
            //x                              z
            anim.SetFloat("runing", Mathf.Abs(facedirection));  //abs ����ֵ
        }
        if (facedirection != 0)
        {
            transform.localScale = new Vector3(facedirection, 1, 1);
        }                                           //x     y    z

        #endregion

        #region ��ɫ��Ծ
        if (Input.GetButtonDown("Jump"))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpfore );

            anim.SetBool("jumping", true);
        }
        #endregion


    }
    void SwitchAnim()
    {
         anim.SetBool("idle", true);
        if (anim.GetBool("jumping"))
        {
            if (rb.velocity.y<0)
            {
                anim.SetBool("jumping", false);
                anim.SetBool("falling", true);
            }
        }else if (coll.IsTouchingLayers(ground))
        {
            anim.SetBool("falling", false);
            anim.SetBool("idle", true);

        }
    }

}









