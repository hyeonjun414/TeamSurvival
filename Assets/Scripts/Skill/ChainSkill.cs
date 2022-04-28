using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChainSkill : Skill
{
    public GameObject hitEffect;    // TODO
    public float chainRange;        // 감지범위
    public int count = 3;           // 번개 개수
    public float interval;          // 번개 사이간격
    Vector2 startPos;
    Vector2 targetPos;
    int targetIndex;                // 랜덤 타겟 index

    public override void Attack()
    {
        StartCoroutine("ChainLightning");
    }

    public override void SetUp()
    {
    }

    public override void LevelUp()
    {
        level++;
        count++;
        damage++;
    }

    // TODO 이미지
    IEnumerator ChainLightning()
    {
        startPos = transform.position;
        yield return null;

        for (int i = 0; i < count; i++)
        {
            Collider2D[] hits = Physics2D.OverlapCircleAll(startPos, chainRange, LayerMask.GetMask("Enemy"));
            
            Debug.Log("hits.Length : " + hits.Length);
            
            if (hits.Length > 0)
            {  // 현재 2연속 같은 대상 공격하긴 함,,
               
                targetIndex = Random.Range(0, hits.Length);

                targetPos = hits[targetIndex].transform.position;
                Debug.Log("Target Name : " + hits[targetIndex].gameObject.name);
                
                IDamageable enemy = hits[targetIndex].GetComponent<IDamageable>();
                if (null != enemy)
                {
                    enemy.Hit(damage);
                    GameManager.Instance.CreateDamage(hits[targetIndex].transform.position, damage);
                }

                if (i % 2 == 0)
                {   // 임시 디버그용 라인
                    Debug.DrawLine(startPos, targetPos, Color.yellow, 1f);
                }
                else{
                    Debug.DrawLine(startPos, targetPos, Color.white, 1f);
                }
                
                // 이펙트 생성 및 회전
                GameObject eff = Instantiate(hitEffect, (targetPos + startPos) / 2f, Quaternion.identity);
                Vector3 dir = targetPos - startPos;
                float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
                eff.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

                startPos = targetPos;

                yield return new WaitForSeconds(interval);
            }
            else{   // 타겟 없으면 조기 종료
                yield break;
            }
        }
    }
}
