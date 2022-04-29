using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour , IDamageable , IAttackable
{
    public float time = 0.1f;
    public float hp ;
    public float velocity ;
    public float dmg;
    public string monsterName;
    public MonsterData monsterData;


    protected Transform playerTransform;
    protected Animator monsterAnimator;
    protected Player player;
    protected SpriteRenderer spriteRenderer;
    protected Rigidbody2D rb;


    private AttackedSprite attackedSprite;

    private bool is_die = false;

    private void Awake()
    {

        monsterAnimator = GetComponent<Animator>();
        player = GameManager.Instance.player;
        playerTransform = player.transform;
        spriteRenderer = GetComponent<SpriteRenderer>();
   


    }

    private void OnEnable()
    {
        if (monsterData != null)
        {
            hp = monsterData.hp;
            dmg = monsterData.hp;
            velocity = monsterData.velocity;
            monsterName = monsterData.monsterName;
        }
    }



    private void FixedUpdate()
    {
        if (!is_die)
        {
            Mover();
        }

       
    }

    virtual public void Mover()
    {

        Vector2 dir = playerTransform.position - gameObject.transform.position;
       
        
        if (Vector3.Distance(playerTransform.position , gameObject.transform.position) > 0.5f)
        {
            if (!monsterAnimator.GetBool("isMove"))
            {
                monsterAnimator.SetBool("isMove", true);

            }

            transform.Translate(dir.normalized * velocity * Time.fixedDeltaTime);
           
           
        }
        else
        {
            Attack();
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

            StartCoroutine(SpriteFade());
           
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



        if (attackedSprite == null)
        {
            gameObject.AddComponent<AttackedSprite>();
            attackedSprite = GetComponent<AttackedSprite>();
            attackedSprite.duration = 0.1f;
            attackedSprite.spriteRenderer = GetComponent<SpriteRenderer>();
        }

        attackedSprite.Attacked(() =>
        {
            Attacked((float)damage);
        });
       
       
    }



    public void Attack()
    {
        if(Vector2.Distance(playerTransform.position , transform.position) < 0.5f)
        {
            player.Hit((int)dmg);
        }


    }

    IEnumerator SpriteFade()
    {
        is_die = true;
        Color color = spriteRenderer.color;
        
        while (color.a > 0) 
        {
            spriteRenderer.color = new Color(255, 255, 255);
            color.a -= 0.01f;
            spriteRenderer.color = color;

            yield return null;
        }

        ObjectPoolConfig config = GetComponent<ObjectPoolConfig>();
        if (config != null)
        {
            is_die = false;
            color.a = 1;
            spriteRenderer.color = color;
            config.Dead();
            // QuestManager.Instance.KillCheck(monsterName);
            //// 아이템 
        }
    }

}
