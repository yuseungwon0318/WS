using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

[System.Serializable]
public class Pool
{
    public string Name;
    public int count;
    public GameObject prefab;
}
public class PoolManager : MonoBehaviour
{
    static public PoolManager Instance;

    public List<Pool> prefabs = new List<Pool>();
    public List<GameObject> pools = new List<GameObject>();

    void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
    }

    public void Init()
    {
        prefabs.ForEach(x =>
        {
            for(int i = 0; i < x.count; i++)
            {
                GameObject item = Instantiate(x.prefab, Vector3.zero, Quaternion.identity, transform);
                item.name = x.Name;
                item.SetActive(false);
                pools.Add(item);
            }
        });
    }

    public GameObject Create(Vector3 pos, string name)
    {
        for(int i = 0; i < pools.Count; i++)
        {
            if(pools[i].name == name)
            {
                if (!pools[i].activeSelf)
                {
                    pools[i].SetActive(true);
                    pools[i].transform.position = pos;
                    return pools[i];
                }
            }
        }

        GameObject item = Instantiate(prefabs.Where(x => x.Name == name).First().prefab);
        pools.Add(item);
        item.transform.position = pos;
        return item;
    }

    public void Remove(GameObject obj)
    {
        obj.SetActive(false);
    }
    
}
