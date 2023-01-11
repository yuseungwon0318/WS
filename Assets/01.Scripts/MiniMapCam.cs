using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MiniMapCam : MonoBehaviour
{
    public Transform target;
    public float Distance;
    public RectTransform rect;
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        rect = GameObject.Find("RawImage").GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(target.position.x, Distance, target.position.z);

        rect.rotation = Quaternion.Euler(0,0,target.rotation.eulerAngles.y);
    }
}
