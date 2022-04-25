using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour, IAttackable
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
                maxExp = maxExp * 1.2f;
                UIManager.Instance.curLevel.text = level.ToString();
                RewardManager.Instance.ExcuteReward();
            }
            print(curExp / maxExp);
            UIManager.Instance.curExpBar.fillAmount = curExp / maxExp;
        }
    }

    Animator anim;
    SpriteRenderer sr;

    float vSpeed;
    float hSpeed;

    public Transform weaponPoint;
    public float weaponDistance = 1f;
    public Vector2 leftHandOffset;
    public Vector2 rightHandOffset;

    public GameObject projectile;

    Vector2 mouse;
    float angle;

    void Start()
    {
        GameManager.Instance.player = this;
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
        ObjectPooling.Instance.AddObjects("aaa", projectile, 5);
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

    public void Attack()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            EXP++;
            GameObject obj = ObjectPooling.Instance.ObjectUse("aaa");
            obj.transform.position = weaponPoint.position;
            obj.transform.rotation = Quaternion.identity * Quaternion.Euler(0, 0, angle);
            Projectile proj = obj.GetComponent<Projectile>();
            proj.SetUp(damage, 2);
            float posX = weaponDistance * 1.5f * Mathf.Cos(angle * Mathf.Deg2Rad);
            float posY = weaponDistance * 1.5f * Mathf.Sin(angle * Mathf.Deg2Rad);
            proj.rb.AddForce(new Vector2(posX, posY) * ShotPower);

            //Projectile proj = Instantiate(obj, weaponPoint.position, Quaternion.identity * Quaternion.Euler(0, 0, angle));

        }
    }

    public void ExpUp(int exp)
    {
        EXP += exp;
        
    }
}
