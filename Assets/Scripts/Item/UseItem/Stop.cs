using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Stop", menuName = "Data/Stop")]
public class Stop : ItemData
{
    private void Start() {
        code = 1;
        maxCount = 5;
    }
    public override void Use()
    {
        Used();
        // 몬스터 정지
    }
}
