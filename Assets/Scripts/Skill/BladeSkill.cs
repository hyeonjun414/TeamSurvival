using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BladeSkill : Skill
{
    public GameObject prfBlade;
    public float duration;

    public override void Attack()
    {
        Blade newBlade = Instantiate(prfBlade, transform.position, Quaternion.identity).GetComponent<Blade>();
        newBlade.duration = duration;
        newBlade.damage = damage;
    }
    
    public override void SetUp()
    {
    }

    public override void LevelUp()
    {
        if (level >= maxLevel) return;
        
        level++;
        duration += 1f;
        cooldown -= 1f;
    }
}
