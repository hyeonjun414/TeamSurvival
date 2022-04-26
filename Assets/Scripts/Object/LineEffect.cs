using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineEffect : Effect
{
    public float duration;
    public float curTime;

    public Vector3 startPos;
    public Vector3 endPos;
    public Color color;

    LineRenderer lr;
    private void Start()
    {
        lr = GetComponent<LineRenderer>();
        lr.SetPosition(0, startPos);
        lr.SetPosition(1, endPos);
    }

    void Update()
    {
        
        curTime += Time.deltaTime;
        if(curTime > duration)
        {
            DestroyMyself();
        }
        Color curColor = new Color(color.r, color.g, color.b, 1 - curTime / duration);
        lr.SetColors(curColor, curColor);
    }
}
