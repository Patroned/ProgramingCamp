using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class fxgo : MonoBehaviour
{
    public float speed=5;
    //public GameObject Bulletpre;
    private Animator anim;//�ڿ�ͷ����[SerializeField]��Ϊ�ɼ����ɸ�
    private Rigidbody2D rb;
    public Collider2D coll;
    public LayerMask ground;
    public float jumpforce;
    
    void Start()
    {
        //��ȡ���
        rb=GetComponent<Rigidbody2D>();
        anim=GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        SwitchAnim();
        //fire();
    }
    void Movement()
    {
        float horizontalMove = Input.GetAxis("Horizontal");
        float facedirection = Input.GetAxisRaw("Horizontal");
        //�ƶ�
        if (horizontalMove != 0)
        {
            rb.velocity = new Vector2(horizontalMove * speed, rb.velocity.y);
            anim.SetFloat("running", Mathf.Abs(facedirection));
        }
        //����
        if (facedirection != 0)
        {
            transform.localScale = new Vector3(facedirection, 1, 1);
            
        }
        //��Ծ
        if (Input.GetButtonDown("Jump")&& coll.IsTouchingLayers(ground))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpforce);
            anim.SetBool("jumping", true);
           // animator.SetBool("jumping", true);
        }
    }
    //�任����
    void SwitchAnim()
    {
        anim.SetBool("idle", false);
        if (anim.GetBool("jumping"))
        {
            if (rb.velocity.y < 0)
            {
                anim.SetBool("jumping", false);
                anim.SetBool("falling", true);
            }
        }
        else if (coll.IsTouchingLayers(ground))
        {
            anim.SetBool("falling", false);
            anim.SetBool("idle", true);
        }
    }
    //���
    /*void fire()
    {
        if (Input.GetMouseButtonDown(0))
        {
              int number = 1;
              Debug.Log(number);
              number++;
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 pos = transform.position;
            //   int randx = Random.Range(0, 360);//���������������
            Vector2 direction = (mousePos - pos).normalized;
            GameObject bullet = Instantiate(Bulletpre, pos, Quaternion.identity);
            bullet.GetComponent<bulletmembers>().SetSpeed(direction);
        }
    }*/
}
