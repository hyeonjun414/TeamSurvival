using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TalentType
{
    HealthUp,
    DamageUp,
    SpeedUp,
    CooltimeReduce,
    Proj_Scale,
    Proj_Speed,
    Proj_MultiShot,
    Proj_PowerUp,
    AttackSpeedUp,
}

[CreateAssetMenu(fileName = "Talent Data", menuName = "Data/Talent Data")]

public class TalentData : RewardData
{

    public TalentType type;
    public float value;

    public override void Select()
    {
        GameManager.Instance.TalentSelect(this);
    }
}
