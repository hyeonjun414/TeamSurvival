using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballSkill : Skill
{
    public Projectile fireball;
    public float range = 10f;

    public float ballScale = 1f;
    public float ballSpeed = 3f;

    protected override void Update()
    {
        base.Update();
    }
    public override void Attack()
    {
        print("파이어볼 스킬 작동");
        Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, range, LayerMask.GetMask("Enemy"));
        if (hits.Length > 0)
        {
            float minDst = 10000f;
            int index = 0;
            for (int i = 0; i < hits.Length; i++)
            {
                if (minDst > (hits[i].transform.position - transform.position).magnitude)
                {
                    minDst = (hits[i].transform.position - transform.position).magnitude;
                    index = i;
                }
            }
            Vector2 dir = (hits[index].transform.position - owner.transform.position).normalized;
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg; ;
            float posX, posY;
            Projectile proj;

            for (int i = -1; i < 2; i++)
            {
                float curAngle = angle + 30 * i;
                posX = Mathf.Cos(curAngle * Mathf.Deg2Rad);
                posY = Mathf.Sin(curAngle * Mathf.Deg2Rad);
                proj = Instantiate(fireball, transform.position, Quaternion.identity * Quaternion.Euler(0, 0, curAngle));
                proj.gameObject.transform.localScale = new Vector3(ballScale, ballScale, 1f);
                proj.SetUp(damage, 20);
                proj.rb.AddForce(new Vector2(posX, posY)* ballSpeed, ForceMode2D.Impulse);

            }
        }

    }

    public override void SetUp()
    {
    }

    public override void LevelUp()
    {
        if (level >= maxLevel) return;
        
        level++;
        ballScale *= 1.1f;
        ballSpeed *= 1.1f;
        damage += 3;
    }
}
