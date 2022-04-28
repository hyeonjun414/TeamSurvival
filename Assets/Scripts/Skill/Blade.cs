using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blade : MonoBehaviour
{
    public int damage = 2;
    public float duration;
    public Vector2 scale = new Vector2(3f, 1.8f);
    public Vector2 dirVec;
    public float speed = 8f;
    Vector2 targetPos;
    int targetIndex = 0;
    float curRenewDelay = 0f;            
    float renewDelay = 1f;          // 목표 재설정 주기
    float attackDelay = 0.1f;
    
    void Start()
    {
        StartCoroutine("CapsuleDamage");
        Destroy(gameObject, duration);
        SetTarget();
    }

    void Update()
    {
        curRenewDelay += Time.deltaTime;

        if (curRenewDelay >= renewDelay)
        {
            SetTarget();
        }
        else{
            ChaseTarget();
        }
    }

    void SetTarget()
    {
        Collider2D[] hits = Physics2D.OverlapCircleAll(gameObject.transform.position, 10f, LayerMask.GetMask("Enemy"));

        if (hits.Length > 0)
        { 
               
            targetIndex = Random.Range(0, hits.Length);

            targetPos = hits[targetIndex].transform.position;
            dirVec = targetPos - new Vector2(transform.position.x, transform.position.y);
        }
        else{
            dirVec = GameManager.Instance.player.transform.position - transform.position;
        }

        curRenewDelay = 0f;
    }

    void ChaseTarget()
    {
        transform.Translate(dirVec.normalized * speed * Time.deltaTime);
    }

    IEnumerator CapsuleDamage()
    {
        while (true)
        {
            Collider2D[] hits = Physics2D.OverlapCapsuleAll(gameObject.transform.position, scale, CapsuleDirection2D.Horizontal, 0, LayerMask.GetMask("Enemy"));

            if (hits.Length > 0)
            {
                Debug.Log("Capsule len : " + hits.Length);
                foreach(Collider2D hit in hits)
                {
                    IDamageable target = hit.transform.GetComponent<IDamageable>();
                    target?.Hit(damage);
                    GameManager.Instance.CreateDamage(hit.transform.position, damage);
                }
            }

            yield return new WaitForSeconds(attackDelay);
        }
    }
}
