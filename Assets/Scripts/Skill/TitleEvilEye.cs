using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleEvilEye : MonoBehaviour
{
    public GameObject target;
    public Effect hitEffect;
    public LineEffect lineEffect;

    public Vector3 followPos = new Vector3(-0.5f, 0.5f, 0);

    public bool isShot = false;

    private void Update()
    {
        if(target != null && !isShot)   
            transform.position = Vector3.Lerp(transform.position, target.transform.position + followPos, Time.deltaTime);

        if(Input.GetButtonDown("Fire1"))
        {
            Click();
        }
    }
    public void Click()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        LineEffect le = Instantiate(lineEffect, transform.position, Quaternion.identity);
        le.startPos = transform.position;
        le.endPos = mousePos;
        Instantiate(hitEffect, mousePos, Quaternion.identity);
        StopCoroutine("StopTrace");
        StartCoroutine("StopTrace");
    }

    IEnumerator StopTrace()
    {
        isShot = true;
        yield return new WaitForSeconds(0.5f);
        isShot = false;
    }

}
