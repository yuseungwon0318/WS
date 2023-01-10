using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System.Linq;

public class NavGenerator : MonoBehaviour
{
    static public NavGenerator instance;
    public List<NavMeshSurface> list = new List<NavMeshSurface>();
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        Generate();
    }
    public void Generate()
    {
        list = gameObject.GetComponents<NavMeshSurface>().ToList();

        list.ForEach(x =>
        {
            x.RemoveData();
            x.BuildNavMesh();
            for(int i = 0; i < x.transform.childCount; i++)
            {
                x.transform.GetChild(i).gameObject.isStatic = false;
            }
            
            Debug.Log("Generate");
        });
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            Generate();
        }
    }
}
