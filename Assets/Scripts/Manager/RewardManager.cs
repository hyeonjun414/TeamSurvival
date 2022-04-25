using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RewardManager : SingletonManager<RewardManager>
{
    public void ExcuteReward()
    {
        GameManager.Instance.PauseGame();
        UIManager.Instance.dlgReward.SetActive(true);
    }

    public void EndReward()
    {
        GameManager.Instance.PlayGame();
        UIManager.Instance.dlgReward.SetActive(false);
    }
}
