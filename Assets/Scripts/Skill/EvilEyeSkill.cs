using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvilEyeSkill : Skill
{
    public Effect hitEffect;
    public LineEffect lineEffect;
    public float range = 20f;
    public int count = 2;

    public Vector3 followPos = new Vector3(-0.5f, 0.5f, 0);

    protected override void Start()
    {
        base.Start();
        gameObject.transform.parent = null;
    }

    protected override void Update()
    {
        base.Update();
        if(owner != null)   
            transform.position = Vector3.Lerp(transform.position, owner.transform.position + followPos, Time.deltaTime);
    }
    public override void Attack()
    {
        print("이블아이 스킬 작동");
        Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, range, LayerMask.GetMask("Enemy"));
        
        if (hits.Length >= 0)
        {
            for(int i = 0; i < count; i++)
            {
                Collider2D hit = hits[Random.Range(0, hits.Length)];
                IDamageable enemy = hit.gameObject.GetComponent<IDamageable>();
                if (enemy != null)
                {
                    print("이블아이 스킬 공격 성공");
                    enemy.Hit(damage);
                    LineEffect le = Instantiate(lineEffect, transform.position, Quaternion.identity);
                    le.startPos = transform.position;
                    le.endPos = hit.transform.position;
                    Instantiate(hitEffect, hit.transform.position, Quaternion.identity);
                }
            }
        }
    }

    public override void SetUp()
    {
        //transform.localScale = new Vector3(range * 2, range * 2, 0);
    }
}
