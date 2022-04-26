using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaAttackSkill : Skill
{
    public Effect hitEffect;
    public float range;

    protected override void Update()
    {
        base.Update();
    }
    public override void Attack()
    {
        print("에이리어 스킬 작동");
        Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, range, LayerMask.GetMask("Enemy"));
        if(hits.Length >= 0)
        {
            foreach(Collider2D hit in hits)
            {
                IDamageable enemy = hit.gameObject.GetComponent<IDamageable>();
                if(enemy != null)
                {
                    print("에어리어 스킬 공격 성공");
                    enemy.Hit(damage);
                    Instantiate(hitEffect, hit.transform.position, Quaternion.identity);
                }
            }
        }
    }

    public override void SetUp()
    {
        transform.localScale = new Vector3(range * 2, range * 2, 0);
    }

}
