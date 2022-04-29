using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour, IAttackable , IDamageable
{
    public float moveSpeed = 1.0f;
    public float ShotPower = 100f;
    public int arrowDamage = 5;
    public int damage = 5;
    public int maxHp = 100;
    public int curHp = 100;
    [SerializeField]
    private int level = 1;
    [SerializeField]
    private float curExp = 0;
    [SerializeField]
    private float maxExp = 10;

    public bool isMultiShot = false;
    public float multiShotAngle = 10f;
    public int projLevel = 0;
    public float coolTime = 1f;
    public float projScale = 1f;
    public float projSpeed = 1f;
    public float attackSpeed = 1f;
    public Slider Hpbar;


    private AttackedSprite attackedSprite;

    public float EXP
    {
        get
        {
            return curExp;
        }
        set
        {
            curExp = value;
            if(curExp >= maxExp)
            {
                level++;
                curExp -= maxExp;
                maxExp = maxExp * 2f;
                UIManager.Instance.curLevel.text = level.ToString();
                RewardManager.Instance.ExcuteReward(RewardType.Skill);
            }
            print(curExp / maxExp);
           UIManager.Instance.curExpBar.fillAmount = curExp / maxExp;
        }
    }
    public int ProjLevel
    {
        get 
        { 
            return projLevel;
        }
        set 
        {
            projLevel = value;
            if(projLevel < GameManager.Instance.projectiles.Length)
            {
                projectile = GameManager.Instance.projectiles[value];
                projKey = projectile.name;
                ObjectPooling.Instance.AddObjects(projKey, projectile, 10);
            }
        }
    }

    Animator anim;
    SpriteRenderer sr;

    float vSpeed;
    float hSpeed;

    public Transform weaponPoint;
    public Transform skillPos;
    public float weaponDistance = 1f;
    public Vector2 leftHandOffset;
    public Vector2 rightHandOffset;

    public GameObject projectile;
    public string projKey = "";

    Vector2 mouse;
    float angle;

    bool isDelay = false;

    void Start()
    {
        GameManager.Instance.player = this;
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
        projectile = GameManager.Instance.projectiles[projLevel];
        projKey = projectile.name;
        ObjectPooling.Instance.AddObjects(projKey, projectile, 10);
        
    }

    void Update()
    {
        if (!GameManager.Instance.isPlay) return;


        Move();

        Tracking();

        Attack();

    }
    private void Move()
    {

        vSpeed = Input.GetAxis("Vertical");
        hSpeed = Input.GetAxis("Horizontal");
        anim.SetFloat("Vertical", vSpeed);
        anim.SetFloat("Horizontal", hSpeed);

        Vector2 moveVec = new Vector2(hSpeed, vSpeed);

        anim.SetFloat("Speed", moveVec.magnitude);


        transform.Translate(new Vector2(hSpeed, vSpeed) * moveSpeed * Time.deltaTime);
    }
    private void Tracking()
    {
        mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        sr.flipX = transform.position.x > mouse.x;

        angle = Mathf.Atan2(mouse.y - transform.position.y, mouse.x - transform.position.x) * Mathf.Rad2Deg;
        float posX = weaponDistance * Mathf.Cos(angle * Mathf.Deg2Rad);
        float posY = weaponDistance * Mathf.Sin(angle * Mathf.Deg2Rad);
        weaponPoint.rotation = Quaternion.AngleAxis(angle-90, Vector3.forward);

        if(transform.position.x > mouse.x)
        {
            sr.flipX = true;
            weaponPoint.position = transform.position + (Vector3)leftHandOffset +new Vector3(posX, posY);
        }
        else
        {
            sr.flipX = false;
            weaponPoint.position = transform.position + (Vector3)rightHandOffset + new Vector3(posX, posY);
        }
        
    }

    public void Hit(int damage)
    {

        if(attackedSprite == null)
        {
            gameObject.AddComponent<AttackedSprite>();
            attackedSprite = GetComponent<AttackedSprite>();
            attackedSprite.duration = 1f;
            attackedSprite.spriteRenderer = GetComponent<SpriteRenderer>();
        }

        attackedSprite.Attacked(() =>
        {

            if (curHp - damage > 0)
            {

                curHp -= damage;
                //Debug.Log(curHp + " / " + maxHp);
                Hpbar.value = (float)curHp / (float)maxHp;

            }
            else
            {
                curHp = 0;
            }

            if (curHp <= 0)
            {
                //GameManager.Instance.PauseGame();
                ObjectPooling.Instance.ObjectPoolingReset();
                //die
                SceneManager.LoadScene("TitleScene");
            }
        });


    }


    public void Attack()
    {
        if (isDelay) return;

        if (Input.GetButtonDown("Fire1"))
        {
            GameObject obj;
            Projectile proj;
            //EXP++;
            float posX;
            float posY;
            if (isMultiShot)
            {
                for(int i = -1; i<2; i++)
                {
                    float curAngle = angle + multiShotAngle * i;
                    obj = ObjectPooling.Instance.ObjectUse(projKey);
                    obj.transform.position = weaponPoint.position;
                    obj.transform.rotation = Quaternion.identity * Quaternion.Euler(0, 0, curAngle);
                    obj.transform.localScale = new Vector3(projScale, projScale, 0);
                    proj = obj.GetComponent<Projectile>();
                    proj.SetUp(damage, 2);
                    posX = weaponDistance * 1.5f * Mathf.Cos(curAngle * Mathf.Deg2Rad);
                    posY = weaponDistance * 1.5f * Mathf.Sin(curAngle * Mathf.Deg2Rad);
                    proj.rb.AddForce(new Vector2(posX, posY) * ShotPower * projSpeed, ForceMode2D.Impulse);
                }
            }
            else
            {
                obj = ObjectPooling.Instance.ObjectUse(projKey);
                obj.transform.position = weaponPoint.position;
                obj.transform.rotation = Quaternion.identity * Quaternion.Euler(0, 0, angle);
                obj.transform.localScale = new Vector3(projScale, projScale, 0);
                proj = obj.GetComponent<Projectile>();
                proj.SetUp(damage, 2);
                posX = weaponDistance * 1.5f * Mathf.Cos(angle * Mathf.Deg2Rad);
                posY = weaponDistance * 1.5f * Mathf.Sin(angle * Mathf.Deg2Rad);
                proj.rb.AddForce(new Vector2(posX, posY) * ShotPower * projSpeed, ForceMode2D.Impulse);
            }

            StartCoroutine("AttackDelay");
        }
    }
    IEnumerator AttackDelay()
    {
        isDelay = true;
        float curTime = 0;
        while(true)
        {
            curTime += Time.deltaTime;
            if(attackSpeed <= curTime)
            {
                isDelay = false;
                yield break;
            }
            else
            {
                UIManager.Instance.curDelayBar.fillAmount = curTime / attackSpeed;
            }
            yield return null;
        }
    }

    public void ExpUp(int exp)
    {
        EXP += exp;
    }

    public void TalentApply(TalentData data)
    {
        switch(data.type)
        {
            case TalentType.HealthUp:
                curHp = (int)(curHp * data.value);
                maxHp = (int)(maxHp * data.value);
                break;
            case TalentType.DamageUp:
                damage = (int)(damage * data.value);
                break;
            case TalentType.SpeedUp:
                moveSpeed = moveSpeed * data.value;
                break;
            case TalentType.CooltimeReduce:
                coolTime *= data.value;
                break;
            case TalentType.Proj_Scale:
                projScale = projScale * data.value;
                break;
            case TalentType.Proj_Speed:
                projSpeed = projSpeed * data.value;
                break;
            case TalentType.Proj_MultiShot:
                isMultiShot = true;
                break;
            case TalentType.Proj_PowerUp:
                ProjLevel++;
                break;
            case TalentType.AttackSpeedUp:
                attackSpeed = attackSpeed * data.value;
                break;
        }
    }

}
