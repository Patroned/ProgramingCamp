using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Animator anim;
    [SerializeField] private Collider2D coll;
    [SerializeField] private Collider2D DisColl;
    [SerializeField] private Transform CellingCheck,GroundCheck;
    //[SerializeField] private AudioSource jumpAudio,hurtAudio,cherryAudio;

    [Space]
    [SerializeField] private float speed;
    [SerializeField] private float JumpForce;

    [Space]
    [SerializeField] private LayerMask ground;
    [SerializeField] private int Cherry,Gem;

    [SerializeField] private Text CherryNum,GemNum;
    private bool isHurt;//默认是false
    private bool isGround;
    private int extraJump;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

    }

    void FixedUpdate()
    {
        if(!isHurt)
        {
            Movement();
        }
        SwitchAnim();
        isGround = Physics2D.OverlapCircle(GroundCheck.position, 0.2f, ground);
        //Jump();
    }

    private void Update()
    {
        newJump();
        //Jump();
        Crouch();
        CherryNum.text = Cherry.ToString();
        GemNum.text = Gem.ToString();
    }
    //移动
    void Movement()
    {
        float horizontalMove = Input.GetAxis("Horizontal");
        float facedirection = Input.GetAxisRaw("Horizontal");


        //角色移动
        if (horizontalMove != 0)
        {
            rb.velocity = new Vector2(horizontalMove * speed * Time.fixedDeltaTime, rb.velocity.y);
            anim.SetFloat("running", Mathf.Abs(facedirection));
        }

        if (facedirection != 0)
        {
            transform.localScale = new Vector3(facedirection, 1, 1);
        }

    }

    //角色跳跃
   /* void Jump()
    {
        if (Input.GetButton("Jump") && coll.IsTouchingLayers(ground))
        {
            rb.velocity = new Vector2(rb.velocity.x, JumpForce * Time.deltaTime);
            jumpAudio.Play();
            anim.SetBool("jumping", true);
        }
    }*/

    void newJump()
    {
        if (isGround)
        {
            extraJump = 1;
        }
        if (Input.GetButtonDown("Jump") && extraJump > 0)
        {
            rb.velocity = Vector2.up * JumpForce; // new Vector2 (0,1)
            extraJump--;
            SoundMananger.instance.JumpAudio();
            anim.SetBool("jumping", true);
        }
        if(Input.GetButtonDown("Jump") && extraJump == 0 && isGround)
        {
            rb.velocity = Vector2.up * JumpForce;
            SoundMananger.instance.JumpAudio();
            anim.SetBool("jumping", true);
        }
    }

    //切换动画效果
    void SwitchAnim()
    {

        if (rb.velocity.y < 0.1f && !coll.IsTouchingLayers(ground))
        {
            anim.SetBool("falling", true);
        }
        if (anim.GetBool("jumping"))
        {
            if (rb.velocity.y < 0)
            {
                anim.SetBool("jumping", false);
                anim.SetBool("falling", true);

            }                                        
        }
        else if(isHurt)
        {
            anim.SetBool("hurt", true);
            anim.SetFloat("running", 0);

            if(Mathf.Abs(rb.velocity.x) < 0.1f)
            {
                anim.SetBool("hurt", false);
                isHurt = false;
            }
        }
        else if (coll.IsTouchingLayers(ground))
        {
            anim.SetBool("falling", false);
        }
    }

    //碰撞触发器
    private void OnTriggerEnter2D(Collider2D collision)
    {

        //收集物品
        if (collision.tag == "Collection_Cherry")
        {
            collision.tag = "null";
            //cherryAudio.Play();
            SoundMananger.instance.CherryAudio();
            collision.GetComponent<Animator>().Play("isGotCherry");
        }

        if (collision.tag == "Collection_Gem")
        {

            collision.tag = "null";
            //cherryAudio.Play();
            SoundMananger.instance.CherryAudio();
            collision.GetComponent<Animator>().Play("isGotGem");           
            
        }

        //死亡线
        if (collision.tag == "DeadLine")
        {
            GetComponent<AudioSource>().enabled = false;
            Invoke("Restart", 2f);
        }
    }

    //消灭敌人
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {

            Enemy enemy = collision.gameObject.GetComponent<Enemy>();
            if (anim.GetBool("falling")) 
            {
                enemy.JumpOn();

                rb.velocity = new Vector2(rb.velocity.x, JumpForce );
                anim.SetBool("jumping", true);
            }

            //受伤
            else if(transform.position.x < collision.gameObject.transform.position.x)
            {
                rb.velocity = new Vector2(-10, rb.velocity. y);
                //hurtAudio.Play();
                SoundMananger.instance.HurtAudio();
                isHurt = true;
            }
            else if (transform.position.x > collision.gameObject.transform.position.x)
            {
                rb.velocity = new Vector2(10, rb.velocity.y);
                //hurtAudio.Play();
                SoundMananger.instance.HurtAudio();
                isHurt = true;
            }
        }
      
    }

    //角色下蹲
    void Crouch()
    {
        if(!Physics2D.OverlapCircle(CellingCheck.position,0.3f,ground))
        {
            if (Input.GetButton("Crouch"))
            {
                anim.SetBool("crouching", true);
                DisColl.enabled = false;
            }
            else
            {
                anim.SetBool("crouching", false);
                DisColl.enabled = true;
            }
        }
    }

    //
    void Restart()
    {
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        
    }

    public void CherryCount()
    {
        Cherry++;
    }

    public void GemCount()
    {
        Gem++;
    }

}
