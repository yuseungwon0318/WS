using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.AI;
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

        Init();
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

        GameObject item = Instantiate(prefabs.Where(x => x.Name == name).First().prefab, transform);
        if(item != null)
        {
            item.name = name;
            pools.Add(item);
            item.transform.position = pos;
        }
        return item;
    }

    public void Remove(GameObject obj)
    {
        obj.SetActive(false);
    }
    
    [ContextMenu("test")]
    public void Test()
    {
        Create(GetRandomPointOnNavMesh(GameObject.FindGameObjectWithTag("Player").transform.position, 10), "Test");
    }
    public void TestRemove()
    {

    }
    private Vector3 GetRandomPointOnNavMesh(Vector3 center, float distance)
    {
        // center�� �߽����� �������� maxDistance�� �� �ȿ����� ������ ��ġ �ϳ��� ����
        // Random.insideUnitSphere�� �������� 1�� �� �ȿ����� ������ �� ���� ��ȯ�ϴ� ������Ƽ
        Vector3 randomPos = Random.insideUnitSphere * distance + center;

        // ����޽� ���ø��� ��� ������ �����ϴ� ����
        NavMeshHit hit;

        // maxDistance �ݰ� �ȿ���, randomPos�� ���� ����� ����޽� ���� �� ���� ã��
        NavMesh.SamplePosition(randomPos, out hit, distance, NavMesh.AllAreas);

        // ã�� �� ��ȯ
        return hit.position;
    }
}
