using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UIManager : SingletonManager<UIManager>
{
    public Text curLevel;
    public Image curExpBar;
    public Image curDelayBar;

    public GameObject dlgReward;
}
