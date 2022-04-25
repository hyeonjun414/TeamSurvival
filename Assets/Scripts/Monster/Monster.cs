using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    public int hp = 50;
    public float velocity = 1;

    private Transform playerTransform;
    private Animator monsterAnimator;
    private SpriteRenderer spriteRenderer;
  
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


