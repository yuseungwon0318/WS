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
    
    public virtual void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
            GetItem();
        }
    }

    public virtual void GetItem()
    {
        PoolManager.Instance.Remove(gameObject);
    }
}
