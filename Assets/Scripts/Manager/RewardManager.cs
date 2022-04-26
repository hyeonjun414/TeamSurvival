using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RewardManager : SingletonManager<RewardManager>
{
    public TalentData[] talentDatas;
    public SkillData[] skillDatas;
    public List<RewardData> rewardList;
    RewardUI rewardUI;

    private void Start()
    {
        rewardUI = UIManager.Instance.dlgReward.GetComponent<RewardUI>();
    }

    public void ExcuteReward(RewardType type)
    {
        if (type == RewardType.Talent)
            RandomTalent();
        else
            RandomSkill();

        GameManager.Instance.PauseGame();
        rewardUI.UpdateUI();
        UIManager.Instance.dlgReward.SetActive(true);
    }

    public void EndReward()
    {
        GameManager.Instance.PlayGame();
        UIManager.Instance.dlgReward.SetActive(false);
        rewardList.Clear();
        rewardUI.UpdateUI();
        
    }

    public void RandomTalent()
    {
        int rand;
        for(int i = 0; rewardList.Count<3;)
        {
            rand = Random.Range(0, talentDatas.Length);
            if (rewardList.Contains(talentDatas[rand]) ||
                (GameManager.Instance.player.isMultiShot && talentDatas[rand].type == TalentType.Proj_MultiShot))
            {
                rand = Random.Range(0, talentDatas.Length);
            }
            else
            {
                rewardList.Add(talentDatas[rand]);
                print(talentDatas[rand]);
                i++;
            }
        }
    }
    public void RandomSkill()
    {
        int rand;
        for (int i = 0; rewardList.Count < 3;)
        {
            rand = Random.Range(0, skillDatas.Length);
            if (rewardList.Contains(skillDatas[rand]))
            {
                rand = Random.Range(0, skillDatas.Length);
            }
            else
            {
                rewardList.Add(skillDatas[rand]);
                print(skillDatas[rand]);
                i++;
            }
        }
    }
}
