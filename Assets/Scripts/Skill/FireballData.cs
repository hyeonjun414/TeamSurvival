using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballData : SkillData
{
    public float count;
    public float interval;
    public float curInterval;
    public Vector2 dir;
    public float speed;
    public float duration;
    
    public override void Use(){
        for (int i = 0; i < count; i++)
        {
            curInterval -= Time.deltaTime;
            if (curInterval <= 0f)
            {
                dir = Vector2.right; // TODO
            
                Fireball fb = Instantiate(prfEffect, Vector3.zero, Quaternion.LookRotation(dir)).GetComponent<Fireball>();
                fb.dir = dir;
                curInterval = interval;
            }
        }
    }

    public override void LevelUp(){
        count++;
    }
}
