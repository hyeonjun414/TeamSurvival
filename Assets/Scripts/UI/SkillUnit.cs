using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillUnit : MonoBehaviour
{
    public Image icon;
    public Skill curSkill;
    public Image coolTimeBar;

    private void Update()
    {
        if(curSkill != null)
        {
            coolTimeBar.fillAmount = 1 - curSkill.curCooldown / curSkill.cooldown;
        }
    }

    public void AddSkill(Skill skill)
    {
        curSkill = skill;

        icon.sprite = skill.data.icon;
        icon.enabled = true;
    }
    public void RemoveSkill()
    {
        curSkill = null;
        coolTimeBar.fillAmount = 1;
        icon.sprite = null;
        icon.enabled = false;
    }
}
