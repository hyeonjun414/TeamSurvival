using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateAroundObject : MonoBehaviour
{
    public float speed;
    public float duration;
    public int damage;
    public float angle;
    //public float attackDelay = 1f;

    void Start()
    {
        Destroy(gameObject, duration);
    }

    void Update()
    {
        RotateAround();
    }

    void RotateAround()
    {
        angle = speed * Time.deltaTime;
        transform.RotateAround(
            GameManager.Instance.player.skillPos.position, 
            Vector3.forward,
            angle);
    }

    void OnTriggerEnter2D(Collider2D other) {
        IDamageable enemy = other.GetComponent<IDamageable>();

        if (null != enemy)
        {
            enemy.Hit(damage);
        }
    }
}
