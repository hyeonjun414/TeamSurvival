using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillManager : SingletonManager<SkillManager>
{
    public List<Skill> skillList;
    public int maxCount = 6;

    SkillUI skillUI;

    private void Start()
    {
        skillUI = UIManager.Instance.dlgSkillSlot.GetComponent<SkillUI>();
    }

    public bool AddSkill(SkillData data)
    {
        print(data.name);
        if (skillList.Count == maxCount)
        {   // 스킬 더 이상 추가 불가한 상태
            return false;
        }
        else{   // 추가 성공
            Player player = GameManager.Instance.player;
            Skill skill = Instantiate(data.targetSkill, player.transform.position, Quaternion.identity, player.skillPos);
            skill.owner = player;
            skill.SetUp();
            skillList.Add(skill);   // TODO UI 갱신
            skillUI.UpdateUI();
            return true;
        }
    }
/*
    public void LevelUp(string skillName)
    {
        foreach (SkillData skillData in listSkill)
        {
            if (skillData.strName == skillName)
            {
                skillData.level++;
            }
        }
    }*/
}
