using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolConfig : MonoBehaviour
{
    [HideInInspector]
    public string key;


    private void OnEnable()
    {
        ObjectPooling.Instance.monstorCount++;
    }
    private void OnDisable()
    {
        ObjectPooling.Instance.monstorCount--;
    }

    public void Dead()
    {

        ObjectPooling.Instance.ObjectReturn(key, gameObject);

    }

}
