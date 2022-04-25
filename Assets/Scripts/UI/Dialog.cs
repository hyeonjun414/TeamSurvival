using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialog : MonoBehaviour
{
    public Animator anim;

    public void SetDisable()
    {
        gameObject.SetActive(false);
    }
}
