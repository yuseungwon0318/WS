using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class DeadCamera : MonoBehaviour
{
    CinemachineVirtualCamera vcam;
    public float min;
    public float max = 6;
    // Start is called before the first frame update
    void Start()
    {
        vcam = GetComponent<CinemachineVirtualCamera>();
        vcam.m_Lens.FieldOfView = max;
    }

    public void Dead()
    {
        StartCoroutine(DeadFOV());
    }
    IEnumerator DeadFOV()
    {
        float i = max;
        while(i >= min)
        {
            i -= 0.05f;
            vcam.m_Lens.FieldOfView = i;
            yield return new WaitForSecondsRealtime(0.01f);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
