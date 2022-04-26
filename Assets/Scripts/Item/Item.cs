using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Item : MonoBehaviour
{
    public string itemName;
    public ItemData myData;
    
    protected void Collect(){
        if (InventoryManager.Instance.Add(myData))
        {
            Destroy(gameObject);
        } 
        else
        {
            // 더 획득할 수 없음.
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        Collect();
    }
}
