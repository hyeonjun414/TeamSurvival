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
    Blade,
}

[CreateAssetMenu(fileName = "Skill Data", menuName = "Data/Skill Data")]
public class SkillData : RewardData
{
    public SkillType skillType;
    public Skill targetSkill;
    
    [TextArea]
    public string desc2LVUp;

    public override void Select()
    {
        SkillManager.Instance.AddSkill(this);
    }

    //
    public void SwitchText() //TODO
    {   // 데이터에 덮으니까 원본 데이터 텍스트가 바뀌어버림
        //desc = desc2LVUp;
    }
}