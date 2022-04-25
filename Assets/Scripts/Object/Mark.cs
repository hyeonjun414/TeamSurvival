using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mark : MonoBehaviour
{
    public Sprite[] sprites;

    SpriteRenderer sr;
    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
    }
    
    public void SetSprite(int index)
    {
        sr.sprite = sprites[index];
    }
}
