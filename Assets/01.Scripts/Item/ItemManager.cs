using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ItemManager : MonoBehaviour
{
    static public ItemManager Instance;
    public float minDelay = 6;
    public float maxDelay = 10;

    public float distance = 10;

    private Transform player;
    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void ItemDrop()
    {
        StartCoroutine(ItemDropping());
    }

    IEnumerator ItemDropping()
    {
        while (GameManager.instance.isStarted)
        {
            float delay = Random.Range(minDelay, maxDelay);

            int select = Random.Range(1, 3);

            GameObject item = null;

            item = PoolManager.Instance.Create(GetRandomPointOnNavMesh(player.transform.position, distance), select == 1 ? "Battery" : "Coin");
            
            while(item.transform.position.y > 2f)
            {
                PoolManager.Instance.Remove(item);
                item = PoolManager.Instance.Create(GetRandomPointOnNavMesh(player.transform.position, distance), select == 1 ? "Battery" : "Coin");
            }

            Debug.Log(item.name);
            yield return new WaitForSeconds(delay);
        }

    }

    private Vector3 GetRandomPointOnNavMesh(Vector3 center, float distance)
    {
        Vector3 randomPos = Random.insideUnitSphere * distance + center;

        NavMeshHit hit;

        NavMesh.SamplePosition(randomPos, out hit, distance, NavMesh.AllAreas);

        // 찾은 점 반환
        return hit.position;
    }
    // Update is called once per frame
    void Update()
    {
        
    }


}
