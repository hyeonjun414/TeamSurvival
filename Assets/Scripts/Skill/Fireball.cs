using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    public Vector2 dir;
    public float speed = 3f;
    public float duration = 2f;

    void Update()
    {
        duration -= Time.deltaTime;
        if(duration <= 0f)
        {
            // TODO 폭발 이펙트 이후 삭제
        }
        else{
            gameObject.transform.Translate(dir * speed);
        }
    }
}
