using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FloatingText : MonoBehaviour
{
    public string key = "floatingDamage";
    public Text damageText;

    private void OnEnable()
    {
        Invoke("ReturnObj", 1f);
    }
    private void Update()
    {
        transform.Translate(Vector2.up * Time.deltaTime);
    }

    public void ReturnObj()
    {
        ObjectPooling.Instance.ObjectReturn(key, gameObject);
    }
}
