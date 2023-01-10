using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Come : MonoBehaviour
{
    public UnityEvent FadeEnded;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(-30, transform.position.y, transform.position.z);
        StartCoroutine(Here());
    }
    IEnumerator Here()
    {
        while(transform.position.x <= 0)
        {
            transform.position += Vector3.right * 0.1f;
            yield return new WaitForSeconds(0.005f);
        }
        FadeEnded?.Invoke();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
