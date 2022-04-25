using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DropItem : Item, ICollectable
{
    public static UnityAction<DropItem> OnGlobalObtain;

    private void Start()
    {
        //OnGlobalObtain += QuestManager.Instance.OnItemCollect(itemName);
    }

    public void Collected()
    {
        InventoryManager.Instance.Add(myData);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            OnGlobalObtain?.Invoke(this);
            Collected();
            Destroy(gameObject);
        }
    }
}
