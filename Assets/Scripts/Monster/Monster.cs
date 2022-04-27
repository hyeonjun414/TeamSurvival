using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour , IDamageable
{
    public float hp ;
    public float velocity ;
    public float dmg;
    public string monsterName;
    public MonsterData monsterData;


    protected Transform playerTransform;
    protected Animator monsterAnimator;
    protected SpriteRenderer spriteRenderer;
    protected Rigidbody2D rb;

    private Color attackedColor;
    private Color noneAttackedColor;
    private int attackedCount = 0;
    private bool is_Attacked = false;


    private void Awake()
    {

        monsterAnimator = GetComponent<Animator>();
        playerTransform = FindObjectOfType<Player>().transform;
        spriteRenderer = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        if(monsterData != null)
        {
            hp = monsterData.hp;
            dmg = monsterData.hp;
            velocity = monsterData.velocity;
            monsterName = monsterData.monsterName;
        }
     

    }

    private void Start()
    {
        attackedColor = new Color(255, 0, 0);
        noneAttackedColor = new Color(255, 255, 255);
        spriteRenderer.color = noneAttackedColor;
        //monsterAnimator.enabled = false;
        //spriteRenderer.enabled = false;
       
    }
    

    private void FixedUpdate()
    {
        //if (!GameManager.Instance.isPlay) return;
        Mover();

        if(!is_Attacked && attackedCount > 0)
        {
            attackedCount--;

            StartCoroutine(AttackedRoutin());
        }

    }

    virtual public void Mover()
    {

        Vector2 dir = playerTransform.position - gameObject.transform.position;
        //transform.Translate(dir.normalized * velocity * Time.deltaTime);
        //transform.position += (Vector3)(dir.normalized * velocity * Time.deltaTime);
        rb.position += (dir.normalized * velocity * Time.deltaTime);
        if (Mathf.Sqrt(dir.x * dir.x + dir.y * dir.y) > 0.5f)
        {
            if (!monsterAnimator.GetBool("isMove"))
            {
                monsterAnimator.SetBool("isMove", true);

            }

            //transform.position += (Vector3)(dir.normalized * velocity * Time.deltaTime);

        }
        else
        {

            if (monsterAnimator.GetBool("isMove"))
            {
                monsterAnimator.SetBool("isMove", false);

            }
        }


        AnimDir(dir);
    }
    private void Attacked(float dmg)
    {
        
        if(hp - dmg > 0)
        {
            hp -= dmg;
        }
        else {

            hp = 0;
        
        }

        if(hp <= 0)
        {

            ObjectPoolConfig config = GetComponent<ObjectPoolConfig>();

            if(config != null)
            {

                string key = config.key;
                ObjectPooling.Instance.ObjectReturn(key, this.gameObject);


                //// 아이템 
            }

        }


    }

    public void AnimDir(Vector2 dir)
    {

        if (dir.x > 0)
        {
            spriteRenderer.flipX = false;
        }
        else
        {
            spriteRenderer.flipX = true;

        }

    }




   public void Hit(int damage) {
        Attacked((float)damage);
        attackedCount++;
    }


    IEnumerator AttackedRoutin()
    {
        float time = 0;  
        spriteRenderer.color = attackedColor;

        is_Attacked = true;
        while (time < 0.5f )
        {
            time += Time.deltaTime;

            
            if(time > 0.3f)
            {

                spriteRenderer.color = noneAttackedColor;

            }                         
            yield return null;
        }

        is_Attacked = false;
    }

}
