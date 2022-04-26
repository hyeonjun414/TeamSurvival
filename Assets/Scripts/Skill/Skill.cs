using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Skill : MonoBehaviour
{   
    public SkillData skillData = null;    
    public float curCooldown = 0f;
    public float cooldown;

    private void Start() {
        if(null != skillData)
        {
            cooldown = skillData.cooldown;
        }
    }
    private void Update() {
        curCooldown += Time.deltaTime;
        if (curCooldown >= cooldown)
        {
            skillData.Use();
            curCooldown = 0f;
        }
        
    }

    public void LevelUp(){
        skillData.level++;
    }
}
