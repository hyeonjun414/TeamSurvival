using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EquipmentType
{
    Weapon,
    Armor
}

[CreateAssetMenu(fileName = "Equip Item", menuName = "Data/EquipItem")]
public class EquipInvenItem : ItemData
{
    public GameObject equipPrefab;
    public EquipmentType eqiupType;

    public int damage;
    public int armor;

    public override void Use()
    {
        Debug.Log($"{name} 을(를) 장착합니다.");
        EquipManager.Instance.Add(this);
        InventoryManager.Instance.Remove(this);
    }
}
