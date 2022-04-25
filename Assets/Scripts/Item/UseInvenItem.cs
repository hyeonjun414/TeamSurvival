using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Use Item", menuName = "Data/UseItem")]
public class UseInvenItem : ItemData
{
    public override void Use()
    {
        Debug.Log($"{name} 을(를) 사용합니다.");
        InventoryManager.Instance.Remove(this);
    }
}
