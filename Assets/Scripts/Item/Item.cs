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
            Debug.Log("최대 개수 입니다.");
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Player")
        {
            Collect();
        }
        
    }
}
