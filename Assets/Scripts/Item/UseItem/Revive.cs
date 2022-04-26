using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Revive", menuName = "Data/Revive")]
public class Revive : ItemData
{
    private void Start() {
        code = 2;    
    }
    public override void Use()
    {
        Used();
        // 플레이어 부활
    }
}
