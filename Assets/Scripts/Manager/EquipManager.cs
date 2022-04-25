using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipManager : MonoBehaviour
{
    private static EquipManager instance;
    public static EquipManager Instance
    {
        get
        {
            if (instance == null)
                instance = FindObjectOfType<EquipManager>();

            return instance;
        }
    }


    public PlayerMover player;
    public EquipInvenItem weapon;
    public EquipmentUI equipmentUI;
    private void Awake()
    {
        instance = this;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            equipmentUI.gameObject.SetActive(!equipmentUI.gameObject.activeSelf);
        }
    }

    public bool Add(EquipInvenItem item)
    {
        bool result = player.Equip(item);
        if (!result) return false;

        weapon = item;
        equipmentUI.UpdateUI();
        return true;
    }

    public void Remove(EquipInvenItem item)
    {
        weapon = null;
        equipmentUI.UpdateUI();
    }
}
