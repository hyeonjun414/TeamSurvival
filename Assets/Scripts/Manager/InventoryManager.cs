using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    private static InventoryManager instance;
    public static InventoryManager Instance
    {
        get
        {
            if (instance == null)
                instance = FindObjectOfType<InventoryManager>();

            return instance;
        }
    }

    public List<ItemData> items = new List<ItemData>(); // 아이템 정보를 가지는 리스트

    public int maxSize = 20; // 인벤토리 허용량

    public InventoryUI inventoryUI;
    private void Awake()
    {
        instance = this;

    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.I))
        {
             inventoryUI.gameObject.SetActive(!inventoryUI.gameObject.activeSelf);
        }
    }

    public bool Add(ItemData item)
    {
        if(items.Count >= maxSize)
        {
            return false;
        }

        items.Add(item);
        inventoryUI.UpdateUI();
        return true;
    }

    public void Remove(ItemData item)
    {
        items.Remove(item);
        inventoryUI.UpdateUI();
    }
}
