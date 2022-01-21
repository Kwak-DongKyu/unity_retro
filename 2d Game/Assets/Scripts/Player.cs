using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public AudioClip audioJump;
    public AudioClip audioAttack;
    public AudioClip audioDamaged;
    public AudioClip audioItem;
    public AudioClip audioDie;
    public AudioClip audioFinish;
    AudioSource audioSource;

    Rigidbody2D rigid;
    public float maxSpeed;
    SpriteRenderer spriteRenderer;
    Animator anim;
    public int jumpPower;
    public gamemanager MG;
    BoxCollider2D boxcollider;

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        boxcollider = GetComponent<BoxCollider2D>();
        audioSource = GetComponent<AudioSource>();
    }
    

    private void Update()
    {
        if (Input.GetButtonUp("Horizontal")) // 버튼 뗐을 때 속도 조절
        {
            rigid.velocity = new Vector2(rigid.velocity.normalized.x * 0.5f, rigid.velocity.y);
            
        }

        if(Input.GetButtonDown("Jump") && !anim.GetBool("isJumping")) //jump
        {
            anim.SetBool("isJumping", true); // 점프시 애니메이션
            rigid.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
            PlaySound("JUMP");
        }
        
        if (Input.GetButton("Horizontal")) //방향전환
        {
            spriteRenderer.flipX = Input.GetAxisRaw("Horizontal") == -1;
        }
        


        if (Mathf.Abs(rigid.velocity.x) < 0.3) // 애니메이션 변경(멈춤, 이동)
        {
            anim.SetBool("isWalking", false);
        }
        else
        {
            anim.SetBool("isWalking", true);
        }

        

    }
    // Update is called once per frame
    void FixedUpdate()
    {
        float a = Input.GetAxisRaw("Horizontal");
        rigid.AddForce(Vector2.right * a , ForceMode2D.Impulse);
            
        
        

        if (rigid.velocity.x > maxSpeed) // max X velocity
        {
            rigid.velocity = new Vector2(maxSpeed, rigid.velocity.y);
        }
        else if (rigid.velocity.x <  maxSpeed * (-1)) // max Y velocity
        {
            rigid.velocity = new Vector2(maxSpeed * (-1) , rigid.velocity.y);
        }
         
        if(rigid.velocity.y < 0 && anim.GetBool("isJumping") )
        {
            Debug.DrawRay(rigid.position, Vector3.down, new Color(0, 1, 0));
            RaycastHit2D rayHit = Physics2D.Raycast(rigid.position, Vector3.down, 1,LayerMask.GetMask("Platform"));
            if(rayHit.collider!= null)
            {
                if (rayHit.distance < 0.8f)
                    anim.SetBool("isJumping", false);
            }

        }


        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //충돌시 피격 이벤트
        if (collision.gameObject.tag == "enemy")
        {
            //attack enemy
            if(rigid.velocity.y < 0 && transform.position.y > collision.transform.position.y)
            {
                onattack(collision.transform);
            }
            else //damaged
                playerDamaged(collision.transform.position);
           
        }
        if(collision.gameObject.tag == "Floor")
        {
            anim.SetBool("isJumping", false);
        }
    }
    
    void playerDamaged(Vector2 target) //피격 이벤트 함수
    {

        

        //sound
        PlaySound("DAMAGED");

        //health down
        MG.HealthDown();

        //layer 변경
        gameObject.layer = 11;

        //색깔 변경
        spriteRenderer.color = new Color(1, 1, 1, 0.4f);

        //튕겨나가는 이벤트
        int dirc = transform.position.x - target.x > 0 ? 1 : -1;
        rigid.AddForce(new Vector2(dirc, 1)*7, ForceMode2D.Impulse);

        anim.SetTrigger("damaged");


        Invoke("Offdamaged", 3);
    }
    void Offdamaged()
    {
        gameObject.layer = 10;
        spriteRenderer.color = new Color(1, 1, 1, 1);
    }

    void onattack(Transform enemy) //enemy 공격 함수
    {
        //sound
        PlaySound("ATTACK");

        //point
        MG.stagePoint += 100;

        //player 반발력
        rigid.AddForce(Vector2.up * 5, ForceMode2D.Impulse);

        //enemy event
        Enemy enemyMove = enemy.GetComponent<Enemy>();
        enemyMove.Ondamaged();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "item")
        {
            //sound
            PlaySound("ITEM");
            //point
            bool isBronze = collision.gameObject.name.Contains("Bronze");
            bool isSilver = collision.gameObject.name.Contains("Silver");
            bool isGOld = collision.gameObject.name.Contains("Gold");

            if (isBronze)
                MG.stagePoint += 50;
            else if (isSilver)
                MG.stagePoint += 100;
            else if (isGOld)
                MG.stagePoint += 300;

            //아이템 사라짐
            collision.gameObject.SetActive(false);
        }
        else if(collision.gameObject.tag == "Finish")
        {
            //sound
            PlaySound("FINISH");
            //next stage
            MG.NextStage();
        }
    }
    public void Ondie()
    {
        //sound
        PlaySound("DIE");

        //sprite alpha
        spriteRenderer.color = new Color(1, 1, 1, 0.4f);
        //sprite flip y
        spriteRenderer.flipY = true;
        //colider disable
        boxcollider.enabled = false;
        //die effect jump
        rigid.AddForce(Vector2.up * 5, ForceMode2D.Impulse);
    }

    public void VelocityZero() //재시작시 속도 0
    {
        rigid.velocity = Vector2.zero;
    }
    void PlaySound(string action) //소리설정
    {
        switch (action)
        {
            case "JUMP":
                audioSource.clip = audioJump;
                audioSource.Play();
                break;
            case "ATTACK":
                audioSource.clip = audioAttack;
                audioSource.Play();
                break;
            case "DAMAGED":
                audioSource.clip = audioDamaged;
                audioSource.Play();
                break;
            case "ITEM":
                audioSource.clip = audioItem;
                audioSource.Play();
                break;
            case "DIE":
                audioSource.clip = audioDie;
                audioSource.Play();
                break;
            case "FINISH":
                audioSource.clip = audioFinish;
                audioSource.Play();
                break;
        }

    }
}
