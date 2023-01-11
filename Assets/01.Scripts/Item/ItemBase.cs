using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class ItemBase : MonoBehaviour
{
    //public UnityEvent CollisionEvt; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public virtual void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            GetItem();
        }
    }

    public virtual void GetItem()
    {
        PoolManager.Instance.Remove(gameObject);
    }
}
