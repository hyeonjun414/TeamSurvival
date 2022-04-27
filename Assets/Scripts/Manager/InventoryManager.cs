using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    public Text slot0;
    public Text slot1;
    public Text slot2;

    public List<ItemData> items = new List<ItemData>(); // 아이템 정보를 가지는 리스트
    public int potionMaxSize = 99; // 최대갯수 제한
    public int stopMaxSize = 5; // 최대갯수 제한
    public int reviveMaxSize = 1; // 최대갯수 제한

    private void Start() {
        // 아이템 개수 초기화
        items[0].curCount = 0;
        items[1].curCount = 0;
        items[2].curCount = 0;
    }

    // public InventoryUI inventoryUI;
    private void Awake()
    {
        instance = this;

    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            // 포션
            if (items[0].curCount != 0)
            {
                items[0].Use();
                slot0.text = " X " + items[0].curCount.ToString();
            } 
        }
        if(Input.GetKeyDown(KeyCode.Alpha2))
        {  
            // 정지
            if (items[1].curCount != 0)
            {
                items[1].Use();
                slot1.text = " X " + items[1].curCount.ToString();
            }
        }
    }

    public bool Add(ItemData item)
    {
        if(item.curCount >= item.maxCount)
        {   

            return false;
        }
        
        item.curCount++;
        if (item.code == 0)
            slot0.text = " X " + items[0].curCount.ToString();
        if (item.code == 1)
            slot1.text = " X " + items[1].curCount.ToString();
        if (item.code == 2)
            slot2.text = " X " + items[2].curCount.ToString();
        
        return true;
    }
}


