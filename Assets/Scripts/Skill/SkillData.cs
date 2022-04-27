using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SkillType
{
    AreaAttack,
    Fireball,
    Laser,
    RotateAround,
    ChainAttack,
}

[CreateAssetMenu(fileName = "Skill Data", menuName = "Data/Skill Data")]
public class SkillData : RewardData
{
    public SkillType skillType;
    public Skill targetSkill;
    public override void Select()
    {
        SkillManager.Instance.AddSkill(this);
    }
}