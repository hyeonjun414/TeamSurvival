using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvilEyeSkill : Skill
{
    public Effect hitEffect;
    public LineEffect lineEffect;
    public float range = 20f;
    public int count = 2;

    public bool isShot = false;

    public Vector3 followPos = new Vector3(-0.5f, 0.5f, 0);

    protected override void Start()
    {
        base.Start();
        gameObject.transform.parent = null;
    }

    protected override void Update()
    {
        base.Update();
        if(owner != null && !isShot)   
            transform.position = Vector3.Lerp(transform.position, owner.transform.position + followPos, Time.deltaTime);
    }
    public override void Attack()
    {
        Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, range, LayerMask.GetMask("Enemy"));
        
        if (hits.Length > 0)
        {
            for(int i = 0; i < count; i++)
            {
                Collider2D hit = hits[Random.Range(0, hits.Length)];
                IDamageable enemy = hit.gameObject.GetComponent<IDamageable>();
                if (enemy != null)
                {
                    enemy.Hit(damage);
                    GameManager.Instance.CreateDamage(hit.transform.position, damage);
                    LineEffect le = Instantiate(lineEffect, transform.position, Quaternion.identity);
                    le.startPos = transform.position;
                    le.endPos = hit.transform.position;
                    Instantiate(hitEffect, hit.transform.position, Quaternion.identity);
                }
            }
            StopCoroutine("StopTrace");
            StartCoroutine("StopTrace");
        }
    }

    public override void SetUp()
    {
    }

    public override void LevelUp()
    {
        if (level >= maxLevel) return;
        
        level++;
        damage += 3;
        count += 2;
    }

    IEnumerator StopTrace()
    {
        isShot = true;
        yield return new WaitForSeconds(0.5f);
        isShot = false;
    }
}
