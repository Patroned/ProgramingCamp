using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControler : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed;
    public float jumpforce;
    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Movement();
    }

    void Movement()
    {
        float horizontalmove = Input.GetAxis("Horizontal");
        float facedirection = Input.GetAxisRaw("Horizontal");

        //��ɫ�ƶ�
        if(horizontalmove != 0)
        {
            rb.velocity = new Vector2(horizontalmove * speed * Time.deltaTime,rb.velocity.y);
            anim.SetFloat("running",Mathf.Abs(horizontalmove));
        }

        if(facedirection != 0)//���ƽ�ɫ����
        {
            transform.localScale = new Vector3(facedirection,1,1);
        }
        //��ɫ��Ծ
        if(Input.GetButtonDown("Jump"))
        {
            rb.velocity = new Vector2(rb.velocity.x,jumpforce * Time.deltaTime);
        }
    }
}
