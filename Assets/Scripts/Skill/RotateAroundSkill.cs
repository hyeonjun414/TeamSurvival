using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateAroundSkill : Skill
{
    public GameObject prfSpawn;
    public float range;
    public float speed;
    public float duration;
    public int count;               // 개수


    public override void Attack()
    {
        Debug.Log("Rot스킬 Attack() 실행");
        for (int i = 0; i < count; i++)
        {
            RotateAroundObject obj = Instantiate(
                prfSpawn, 
                GameManager.Instance.player.skillPos.position + Vector3.up * range,
                Quaternion.identity, 
                gameObject.transform)
                .GetComponent<RotateAroundObject>();

            obj.transform.RotateAround(
                GameManager.Instance.player.skillPos.position, 
                Vector3.forward, 
                i * 360 / count);
            
            obj.speed = speed;
            obj.duration = duration;
            obj.damage = damage;
        }
    }

    public override void SetUp()
    {
    }

    public override void LevelUp()
    {
        if (level >= maxLevel) return;
        
        level++;
        count++;
    }
}
