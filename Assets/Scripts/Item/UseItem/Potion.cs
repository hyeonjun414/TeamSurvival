using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Potion", menuName = "Data/Potion")]
public class Potion : ItemData
{
    private void Start() {
        code = 0;
        maxCount = 99;
    }
    public override void Use()
    {
        Used();
        // 플레이어 체력 회복
    }
}
