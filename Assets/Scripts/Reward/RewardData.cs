using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum RewardType
{
    Talent,
    Skill
}

public abstract class RewardData : ScriptableObject
{
    new public string name;
    [TextArea]
    public string desc;
    public Sprite icon;

    public RewardType rewardType;

    public abstract void Select();
}
