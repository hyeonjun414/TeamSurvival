using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour,IDamageable
{
    public int hp = 50;
    public float velocity = 1;
    public float dmg;
    private Transform playerTransform;
    private Animator monsterAnimator;
    private SpriteRenderer spriteRenderer;

    public void Hit(int damage)
    {
        hp -= damage;
    }

    private void Awake()
    {

        monsterAnimator = GetComponent<Animator>();
        playerTransform = FindObjectOfType<Player>().transform;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        Vector2 dir = playerTransform.position - gameObject.transform.position;
        transform.Translate(dir.normalized * velocity * Time.deltaTime);

        if(dir.x > 0)
        {
            spriteRenderer.flipX = false;
        }
        else
        {
            spriteRenderer.flipX = true;

        }

    }

    


}


