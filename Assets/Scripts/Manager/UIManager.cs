using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UIManager : SingletonManager<UIManager>
{
    public Text curLevel;
    public Text curTime;
    public Image curExpBar;
    public Image curDelayBar;


    public GameObject dlgReward;
    public GameObject dlgSkillSlot;


}
