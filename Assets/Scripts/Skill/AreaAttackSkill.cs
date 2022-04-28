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
        Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, range, LayerMask.GetMask("Enemy"));
        if(hits.Length >= 0)
        {
            foreach(Collider2D hit in hits)
            {
                IDamageable enemy = hit.gameObject.GetComponent<IDamageable>();
                if(enemy != null)
                {
                    enemy.Hit(damage);
                    GameManager.Instance.CreateDamage(hit.transform.position, damage);
                    Instantiate(hitEffect, hit.transform.position, Quaternion.identity);
                }
            }
        }
    }

    public override void SetUp()
    {
        transform.localScale = new Vector3(range * 2, range * 2, 0);
    }

    public override void LevelUp()
    {
        // TODO
        level++;
        range += 1;
        damage += 1;
        SetUp();
    }

}
