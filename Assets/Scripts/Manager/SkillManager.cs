using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillManager : MonoBehaviour
{
     private static SkillManager instance;
    public static SkillManager Instance
    {
        get
        {
            if (instance == null)
                instance = FindObjectOfType<SkillManager>();

            return instance;
        }
    }

    public List<SkillData> listSkill;
    int maxCount = 6;

    private void Awake()
    {
        instance = this;
            
    }

    public bool AddSkill(SkillData skillData)
    {
        if (listSkill.Count == maxCount)
        {   // 스킬 더 이상 추가 불가한 상태
            return false;
        }
        else{   // 추가 성공
            listSkill.Add(skillData);   // TODO UI 갱신
            return true;
        }
    }

    public void LevelUp(string skillName)
    {
        foreach (SkillData skillData in listSkill)
        {
            if (skillData.strName == skillName)
            {
                skillData.level++;
            }
        }
    }
}
