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

    public bool AddSkill(SkillData addData)
    {
        print(addData.name);
        if (skillList.Count == maxCount)
        {   // 스킬 더 이상 추가 불가한 상태
            return false;
        }
        else{   // 추가 성공

            foreach(Skill skill in skillList)
            {
                if (skill.data.skillType == addData.skillType)
                {   // 이미 있는 경우,, 
                    skill.LevelUp();
                    return true;
                }
            }

            // 없는 경우,, 새로 추가
            Player player = GameManager.Instance.player;
            Skill newSkill = Instantiate(addData.targetSkill, player.transform.position, Quaternion.identity, player.skillPos);
            newSkill.owner = player;
            newSkill.SetUp();
            skillList.Add(newSkill); 
            skillUI.UpdateUI();
            return true;
        }
    }
}
