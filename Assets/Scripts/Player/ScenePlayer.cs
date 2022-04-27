using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScenePlayer : MonoBehaviour
{
    public GameObject rotationPos;
    public GameObject gatePos;

    public float curTime = 0;

    private SpriteRenderer sr;

    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }
    private void Update()
    {
        curTime += Time.deltaTime;
        transform.position = rotationPos.transform.position + new Vector3(Mathf.Cos(curTime) * 3, Mathf.Sin(curTime) * 3, 0);

        if(transform.position.y > rotationPos.transform.position.y)
        {
            sr.flipX = true;
        }
        else
        {
            sr.flipX = false;
        }
    }
}
