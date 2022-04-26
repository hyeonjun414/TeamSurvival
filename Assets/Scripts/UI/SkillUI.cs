using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillUI : MonoBehaviour
{
    public SkillUnit[] skillUnits;

    private void Start()
    {
        skillUnits = GetComponentsInChildren<SkillUnit>();
    }
    public void UpdateUI()
    {

        for (int i = 0; i < skillUnits.Length; i++)
        {
            if (i < SkillManager.Instance.skillList.Count)
            {
                skillUnits[i].AddSkill(SkillManager.Instance.skillList[i]);
            }
            else
            {
                skillUnits[i].RemoveSkill();
            }
        }
    }
}
