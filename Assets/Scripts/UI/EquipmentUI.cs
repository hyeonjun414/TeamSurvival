using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentUI : MonoBehaviour
{
    public EquipmentUnit weapon;
    //public EquipmentUnit armor;

    public void UpdateUI()
    {
        PlayerMover player = EquipManager.Instance.player;
        if(player.weapon != null)
        {
            weapon.AddItem(EquipManager.Instance.weapon);
        }
    }
}
