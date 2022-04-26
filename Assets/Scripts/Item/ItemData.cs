using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ItemData : ScriptableObject // 데이터 자체를 스크립트로 생성함.
{
    new public string   name = "New Item";
    public int code = 0;
    public int curCount = 0;    // 현재 가지고 있는 아이템 갯수
    public int maxCount = 1;
    public GameObject prefab = null;
    public Sprite       icon = null;

    // 인벤토리에서 사용하는 아이템
    // 포션, 밀어내기, 부활

    public abstract void Use();
    public void Used()
    {
        curCount--;
    }
}
