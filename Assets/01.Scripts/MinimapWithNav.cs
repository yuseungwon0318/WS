using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MinimapWithNav : MonoBehaviour
{
    static public MinimapWithNav Instance;
    // Start is called before the first frame update
    void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
    }
    [ContextMenu("¹Ì´Ï¸Ê")]
    public void CreateMesh()
    {
        MeshFilter filter = GetComponent<MeshFilter>();
        NavMeshTriangulation tris = NavMesh.CalculateTriangulation();

        Mesh mesh = new Mesh();
        mesh.vertices = tris.vertices;
        mesh.triangles = tris.indices;

        filter.mesh = mesh;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
