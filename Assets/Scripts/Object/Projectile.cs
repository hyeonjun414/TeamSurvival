using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public Rigidbody2D rb;
    public int damage;

    public Effect effect;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    public void SetUp(int damage, int duration)
    {
        this.damage = damage;
        //Destroy(gameObject, duration);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Enemy" && !other.isTrigger)
        {
            IDamageable enemy = other.GetComponent<IDamageable>();
            enemy?.Hit(damage);

            if (effect != null)
            {
                Instantiate(effect, transform.position, Quaternion.identity);

            }
            //Destroy(gameObject);
            ObjectPooling.Instacne.ObjectReturn("aaa",gameObject);
            gameObject.SetActive(false);
        }
        else if(other.tag == "Wall")
        {
            if(effect != null)
            {
                Instantiate(effect, transform.position, Quaternion.identity);

            }
            //Destroy(gameObject);
            ObjectPooling.Instacne.ObjectReturn("aaa", gameObject);
        }
        
    }
}
