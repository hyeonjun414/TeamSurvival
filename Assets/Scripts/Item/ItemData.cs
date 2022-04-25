using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ItemData : ScriptableObject // 데이터 자체를 스크립트로 생성함.
{
    new public string   name = "New Item";

    public Sprite       icon = null;
    public GameObject   prefab = null;

    // 인벤토리 창에서 사용하는 작업
    // 아이템의 종류에 따라 기능이 다름 -> 자식에서 재정의 해야함.
    public abstract void Use();
    public void Remove()
    {
        // 인벤토리 창에서 지우는 작업
        InventoryManager.Instance.Remove(this);
    }

}
