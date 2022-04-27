using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName ="monster" , menuName ="monster/monster")]
public class MonsterData : ScriptableObject
{
    public string monsterName;
    public float hp;
    public float damage;
    public float velocity;
    public Sprite image;
    public int count;
    public int maxCount;
    public GameObject monsterObj;
    



}
