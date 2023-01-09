using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;

[RequireComponent(typeof(KickboardController))]
public class TouchScreen : MonoBehaviour
{
    KickboardController kickboardController;
    void Start()
    {
        kickboardController = GetComponent<KickboardController>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float horizontal = 0;
        if(Input.touchCount > 0)
        {
            if (Input.GetTouch(0).position.x > Screen.width/2)
            {
                horizontal = 1;
            }
            else if(Input.GetTouch(0).position.x < Screen.width/2)
            {
                horizontal = -1;
            }
        }
        kickboardController.Move(1, horizontal);
    }
}
