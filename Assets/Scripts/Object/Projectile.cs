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
        Invoke("ReturnProj", duration);
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.tag == "Enemy" && !other.collider.isTrigger)
        {
            IDamageable enemy = other.collider.GetComponent<IDamageable>();
            enemy?.Hit(damage);

            if (effect != null)
            {
                
                Instantiate(effect, other.contacts[0].point, Quaternion.identity);
            }
            ReturnProj();
        }
        else if (other.collider.tag == "Wall")
        {
            if (effect != null)
            {
                Instantiate(effect, other.contacts[0].point, Quaternion.identity);
            }
            ReturnProj();
        }
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
            ReturnProj();
            gameObject.SetActive(false);
        }
        else if(other.tag == "Wall")
        {
            if(effect != null)
            {
                Instantiate(effect, transform.position, Quaternion.identity);
            }
            ReturnProj();
        }
        
    }
    public void ReturnProj()
    {
        ObjectPooling.Instance.ObjectReturn("aaa", gameObject);
    }
    private void OnDisable()
    {
        rb.velocity = Vector3.zero;
        damage = 0;
        CancelInvoke("ReturnProj");
    }
}
