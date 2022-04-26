using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SkillData", menuName = "Data/SkillData")]
public abstract class SkillData : ScriptableObject
{   // TODO name, desc, icon만 가지는 부모를 상속받기
    public string strName = "";
    public string description = "";
    public GameObject prfEffect;
    public GameObject prfIcon;
    public float cooldown;

    int _maxLevel = 8;
    public int maxLevel{
        get{
            return _maxLevel;
        }
    }

    int _level = 1;
    public int level{
        get{
            return _level;
        }

        set{
            if (_level < value || value > maxLevel)
            {
                return;
            }
            _level = value;
            LevelUp();
        }
    }
    public abstract void Use();
    public abstract void LevelUp();
}