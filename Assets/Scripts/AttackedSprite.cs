using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class AttackedSprite : MonoBehaviour
{

    public float duration;
    public SpriteRenderer spriteRenderer;
    private bool is_attacked = false;
    private Color attackedColor;
    private Color noneAttackedcolor ;

    private void Awake()
    {
       attackedColor = new Color(255, 0, 0);
       noneAttackedcolor = new Color(255, 255, 255);

     }


     private void OnEnable()
    {
        is_attacked = false;

        if (spriteRenderer != null)
        {
            spriteRenderer.color = noneAttackedcolor;
        }
    }




    public void Attacked(Action action)
    {

        if (!is_attacked)
        {
            is_attacked = true;

            StartCoroutine(AttackedColorChangeRoutin());

            if (action != null)
            {
                action();
            }
        }


    } 



    IEnumerator AttackedColorChangeRoutin()
    {
        float time = 0f;
        spriteRenderer.color = attackedColor;
        while (time < duration)
        {
            time += Time.deltaTime;

            

            yield return null;
        }

        if (is_attacked)
        {
            is_attacked = false;
        }
        spriteRenderer.color = noneAttackedcolor;
    }

    

}
