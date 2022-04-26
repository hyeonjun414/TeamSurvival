using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RewardUI : MonoBehaviour
{
    public RewardUnit[] items;

    private void Start()
    {
        //items = GetComponentsInChildren<RewardUnit>();
    }
    public void UpdateUI()
    {
        
        for(int i = 0; i< items.Length; i++)
        {
            if(i < RewardManager.Instance.rewardList.Count)
            {
                items[i].AddReward(RewardManager.Instance.rewardList[i]);
            }
            else
            {
                items[i].RemoveReward();
            }
        }
    }
}
