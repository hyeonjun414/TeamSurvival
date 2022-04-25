using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EquipmentUnit : MonoBehaviour
{
    public Button button;
    public Image icon;

    EquipInvenItem curItemData;

    public void AddItem(EquipInvenItem itemData)
    {
        curItemData = itemData;

        icon.sprite = itemData.icon;
        icon.enabled = true;
        button.interactable = true;
    }
    public void RemoveItem()
    {
        curItemData = null;

        icon.sprite = null;
        icon.enabled = false;
        button.interactable = false;

    }

    public void UnEquip()
    {
        bool result = EquipManager.Instance.player.UnEquip(curItemData.eqiupType);
        if (!result) return;
        InventoryManager.Instance.Add(curItemData);
        EquipManager.Instance.Remove(curItemData);
        RemoveItem();

    }
}
