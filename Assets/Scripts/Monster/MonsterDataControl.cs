using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterDataControl : SingletonManager<MonsterDataControl>
{
    public void SetData(string key , float hp , float velocity , float damage)
    {
      var managedMonster =  ObjectPooling.Instance.objectsDictionary;


        if (!managedMonster.ContainsKey(key))
        {
            Debug.LogError("MonsterDataContol : 키 없음");
            return;
        }

        var objStack = managedMonster[key];

        GameObject[] objs =  objStack.ToArray();

        foreach(var obj in objs)
        {
            Monster monster = obj.GetComponent<Monster>();

            monster.hp = hp;
            monster.velocity = velocity;
            monster.dmg = damage;

        }



    }



}
