using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    InventoryUnit[] items;

    public void UpdateUI()
    {
        items = GetComponentsInChildren<InventoryUnit>();
        for(int i = 0; i< items.Length; i++)
        {
            if(i < InventoryManager.Instance.items.Count)
            {
                items[i].AddItem(InventoryManager.Instance.items[i]);
            }
            else
            {
                items[i].RemoveItem();
            }
        }
    }
}
