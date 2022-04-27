using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Potion", menuName = "Data/Potion")]
public class Potion : ItemData
{
    // public Player player;
    private void Start() {
        code = 0;
        maxCount = 99;
    }
    public override void Use()
    {
        Used();
        // player.curHp = player.curHp + 10;
        // 플레이어 체력 회복
    }
}
