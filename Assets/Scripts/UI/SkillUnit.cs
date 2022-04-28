using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillUnit : MonoBehaviour
{
    public Image icon;
    public Skill curSkill;
    public Text curSkillLevel;
    public GameObject skillLevelSlot;
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
        curSkillLevel.text = curSkill.level.ToString();
        skillLevelSlot.SetActive(true);
        icon.enabled = true;
    }
    public void RemoveSkill()
    {
        curSkill = null;
        coolTimeBar.fillAmount = 1;
        icon.sprite = null;
        skillLevelSlot.SetActive(false);

        icon.enabled = false;
    }
}
