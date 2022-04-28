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
    }
    
    public override void SetUp()
    {
        // TODO
    }

    public override void LevelUp()
    {
        // TODO
        level++;
        duration += 1f;
        cooldown -= 1f;
        //scale;
    }
}
