using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RewardUnit : MonoBehaviour
{
    public Button button;
    public Image icon;
    public Text title;
    public Text desc;

    [SerializeField]
    RewardData curItemData;

    public void AddReward(RewardData data)
    {
        curItemData = data;

        icon.sprite = data.icon;
        title.text = data.name;
        desc.text = data.desc;
        icon.enabled = true;
        button.interactable = true;
    }
    public void RemoveReward()
    {
        curItemData = null;

        icon.sprite = null;
        title.text = "보상 이름";
        desc.text = "보상 내용";
        icon.enabled = false;
        button.interactable = false;
    }

    public void SelectReward()
    {
        curItemData.Select();
        RewardManager.Instance.EndReward();
    }
}
