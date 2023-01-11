using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class ItemBase : MonoBehaviour
{
    public KickboardController Player;
    //public UnityEvent CollisionEvt; 
    // Start is called before the first frame update
    public virtual void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player").GetComponent<KickboardController>();
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
