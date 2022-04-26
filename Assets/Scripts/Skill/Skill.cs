using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Skill : MonoBehaviour,IAttackable
{
    public Player owner;
    public float curCooldown = 0f;
    public float cooldown;
    public int damage;

    public SkillData data;

    protected virtual void Start()
    {
        owner = GameManager.Instance.player;
    }

    protected virtual void Update() {
        curCooldown += Time.deltaTime;
        if (curCooldown >= cooldown)
        {
            Attack();
            curCooldown = 0f;
        }
        
    }

    public abstract void Attack();
    public abstract void SetUp();
}
