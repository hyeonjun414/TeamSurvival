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
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
        ObjectPooling.Instacne.AddObjects("aaa", projectile, 5);
    }

    void Update()
    {
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
        if (Input.GetButton("Fire1"))
        {
            GameObject obj = ObjectPooling.Instacne.ObjectUse("aaa");
            obj.transform.position = weaponPoint.position;
            obj.transform.rotation = Quaternion.identity * Quaternion.Euler(0, 0, angle);
            Projectile proj = obj.GetComponent<Projectile>();
            proj.SetUp(damage, 2);
            float posX = weaponDistance * Mathf.Cos(angle * Mathf.Deg2Rad);
            float posY = weaponDistance * Mathf.Sin(angle * Mathf.Deg2Rad);
            proj.rb.AddForce(new Vector2(posX, posY) * ShotPower);

            //Projectile proj = Instantiate(obj, weaponPoint.position, Quaternion.identity * Quaternion.Euler(0, 0, angle));

        }
    }
}
