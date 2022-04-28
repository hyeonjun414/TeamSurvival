using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class InGameCamera : MonoBehaviour
{
    public CinemachineVirtualCamera virCam;
    void Update()
    {
        float wheelInput = Input.GetAxis("Mouse ScrollWheel");
        if (wheelInput != 0)
        {
            virCam.m_Lens.OrthographicSize -= wheelInput * 5;
            if(virCam.m_Lens.OrthographicSize < 2)
            {
                virCam.m_Lens.OrthographicSize = 2;
            }
            else if(virCam.m_Lens.OrthographicSize > 20)
            {
                virCam.m_Lens.OrthographicSize = 20;
            }
        }
    }
}
