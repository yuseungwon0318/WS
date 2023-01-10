using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapSetting : MonoBehaviour
{
    MapManager mapManager;

    private bool a; 
    
    private MeshCollider Mcollider;
    private MeshFilter Mfilter;
    public int i;

    public GameObject Prefabs;

    public int Length;
    public int Height;

    public List<Mesh> cornerMesh = new List<Mesh>();
    public List<Mesh> centerMesh = new List<Mesh>();
    public List<Mesh> sideMesh = new List<Mesh>();

    public bool up;
    public bool left;
    public bool right;
    public bool down;

    private void Start()
    {
        
        Mfilter = GetComponent<MeshFilter>();
        Mcollider = GetComponent<MeshCollider>();
        RandomMap();
        
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q))
        {
            RandomMap();
            Debug.Log(i);
}
    }

    public void RandomMap()
    {
        

        switch(int.Parse(gameObject.name))
        {
            case 1:
                Mfilter.mesh = cornerMesh[0];
                Mcollider.sharedMesh = Mfilter.mesh;
                transform.position = new Vector3(30, 0, 0);
                transform.rotation = Quaternion.Euler(-90, -90, 0);

                break;

            case 2:
                i = Random.Range(1, 4);
                

                if (i == 0 || i == 1)
                {
                    
                    if (i == 0)
                    {
                        Mfilter.mesh = sideMesh[0];
                        Mcollider.sharedMesh = Mfilter.mesh;
                        MapManager.Instance.A = false;
                    }
                    else
                    {
                        Mfilter.mesh = sideMesh[1];
                        Mcollider.sharedMesh = Mfilter.mesh;
                        MapManager.Instance.A = false;
                    }

                    transform.position = new Vector3(15, 0, 0);
                    transform.rotation = Quaternion.Euler(-90, 90, 0);
                }
                else
                {
                    MapManager.Instance.A = true;

                    Mfilter.mesh = sideMesh[2];
                    Mcollider.sharedMesh = Mfilter.mesh;

                    transform.position = new Vector3(15, 0, 0);
                    transform.rotation = Quaternion.Euler(-90, 0, 0);
                }

                break;

            case 3:
                i = Random.Range(1, 4);


                if (i == 0 || i == 1)
                {

                    
                    if (i == 0)
                    {
                        Mfilter.mesh = sideMesh[0];
                        Mcollider.sharedMesh = Mfilter.mesh;
                        MapManager.Instance.B = false;
                    }
                    else
                    {
                        Mfilter.mesh = sideMesh[1];
                        Mcollider.sharedMesh = Mfilter.mesh;
                        MapManager.Instance.B = false;
                    }

                    transform.position = new Vector3(0, 0, 0);
                    transform.rotation = Quaternion.Euler(-90, 90, 0);
                }
                else
                {
                    MapManager.Instance.B = true;

                    Mfilter.mesh = sideMesh[2];
                    Mcollider.sharedMesh = Mfilter.mesh;

                    transform.position = new Vector3(0, 0, 0);
                    transform.rotation = Quaternion.Euler(-90, 0, 0);
                }

                break;
            case 4:
                Mfilter.mesh = cornerMesh[0];
                Mcollider.sharedMesh = Mfilter.mesh;
                transform.position = new Vector3(-15, 0, 0);
                transform.rotation = Quaternion.Euler(-90, 0, 0);

                break;
            case 5:
                i = Random.Range(1, 4);


                if (i == 0 || i == 1)
                {
                    
                    if (i == 0)
                    {
                        Mfilter.mesh = sideMesh[0];
                        Mcollider.sharedMesh = Mfilter.mesh;
                        MapManager.Instance.C = false;
                    }
                    else
                    {
                        Mfilter.mesh = sideMesh[1];
                        Mcollider.sharedMesh = Mfilter.mesh;
                        MapManager.Instance.C = false;
                    }

                    transform.position = new Vector3(30, 0, 15);
                    transform.rotation = Quaternion.Euler(-90, 0, 0);
                }
                else
                {
                    MapManager.Instance.C = true;

                    Mfilter.mesh = sideMesh[2];
                    Mcollider.sharedMesh = Mfilter.mesh;

                    transform.position = new Vector3(30, 0, 15);
                    transform.rotation = Quaternion.Euler(-90, 270, 0);
                }

                break;
            case 6:

                up = MapManager.Instance.A;
                left = MapManager.Instance.C;
                right = MapManager.Instance.D;
                down = MapManager.Instance.G;


                if (up && left && right && down)
                {
                    i = Random.Range(3, 6);

                    Mfilter.mesh = centerMesh[i];
                    Mcollider.sharedMesh = Mfilter.mesh;

                    transform.position = new Vector3(15, 0, 15);
                    transform.rotation = Quaternion.Euler(-90, -90, 0);
                }
                else if (left && right && down)
                {

                    Mfilter.mesh = centerMesh[2];
                    Mcollider.sharedMesh = Mfilter.mesh;

                    transform.position = new Vector3(15, 0, 15);
                    transform.rotation = Quaternion.Euler(-90, 0, 0);
                }
                else if (up && right && down)
                {
                    Mfilter.mesh = centerMesh[2];
                    Mcollider.sharedMesh = Mfilter.mesh;

                    transform.position = new Vector3(15, 0, 15);
                    transform.rotation = Quaternion.Euler(-90, 270, 0);
                }
                else if (up && left && down)
                {
                    Mfilter.mesh = centerMesh[2];
                    Mcollider.sharedMesh = Mfilter.mesh;

                    transform.position = new Vector3(15, 0, 15);
                    transform.rotation = Quaternion.Euler(-90, 90, 0);
                }
                else if (up && left && right)
                {
                    Mfilter.mesh = centerMesh[2];
                    Mcollider.sharedMesh = Mfilter.mesh;

                    transform.position = new Vector3(15, 0, 15);
                    transform.rotation = Quaternion.Euler(-90, 180, 0);
                }
                else if (up && down)
                {
                    int i = Random.Range(1, 3);

                    switch (i)
                    {
                        case 1:
                            Mfilter.mesh = centerMesh[0];
                            Mcollider.sharedMesh = Mfilter.mesh;

                            transform.position = new Vector3(15, 0, 15);
                            transform.rotation = Quaternion.Euler(-90, 180, 0);
                            break;

                        case 2:
                            Mfilter.mesh = centerMesh[1];
                            Mcollider.sharedMesh = Mfilter.mesh;

                            transform.position = new Vector3(15, 0, 15);
                            transform.rotation = Quaternion.Euler(-90, 180, 0);
                            break;
                    }

                }
                else if (left && right)
                {
                    int i = Random.Range(1, 3);

                    switch (i)
                    {
                        case 1:
                            Mfilter.mesh = centerMesh[0];
                            Mcollider.sharedMesh = Mfilter.mesh;

                            transform.position = new Vector3(15, 0, 15);
                            transform.rotation = Quaternion.Euler(-90, 90, 0);
                            break;

                        case 2:
                            Mfilter.mesh = centerMesh[1];
                            Mcollider.sharedMesh = Mfilter.mesh;

                            transform.position = new Vector3(15, 0, 15);
                            transform.rotation = Quaternion.Euler(-90, 90, 0);
                            break;
                    }
                }
                else if (up && left)
                {
                    Mfilter.mesh = centerMesh[6];
                    Mcollider.sharedMesh = Mfilter.mesh;

                    transform.position = new Vector3(15, 0, 15);
                    transform.rotation = Quaternion.Euler(-90, 90, 0);
                }
                else if (up && right)
                {
                    Mfilter.mesh = centerMesh[6];
                    Mcollider.sharedMesh = Mfilter.mesh;

                    transform.position = new Vector3(15, 0, 15);
                    transform.rotation = Quaternion.Euler(-90, 180, 0);
                }
                else if (down && left)
                {
                    Mfilter.mesh = centerMesh[6];
                    Mcollider.sharedMesh = Mfilter.mesh;

                    transform.position = new Vector3(15, 0, 15);
                    transform.rotation = Quaternion.Euler(-90, 0, 0);
                }
                else if (down && right)
                {
                    Mfilter.mesh = centerMesh[6];
                    Mcollider.sharedMesh = Mfilter.mesh;

                    transform.position = new Vector3(15, 0, 15);
                    transform.rotation = Quaternion.Euler(-90, 270, 0);
                }
                else
                {
                    Mfilter.mesh = centerMesh[7];
                    Mcollider.sharedMesh = Mfilter.mesh;

                    transform.position = new Vector3(15, 0, 15);
                    transform.rotation = Quaternion.Euler(-90, 270, 0);
                }



                break;

            case 7:

                up = MapManager.Instance.B;
                left = MapManager.Instance.C;
                right = MapManager.Instance.D;
                down = MapManager.Instance.H;


                if (up && left && right && down)
                {
                    i = Random.Range(3, 6);

                    Mfilter.mesh = centerMesh[i];
                    Mcollider.sharedMesh = Mfilter.mesh;

                    transform.position = new Vector3(0, 0, 15);
                    transform.rotation = Quaternion.Euler(-90, -90, 0);
                }
                else if (left && right && down)
                {

                    Mfilter.mesh = centerMesh[2];
                    Mcollider.sharedMesh = Mfilter.mesh;

                    transform.position = new Vector3(0, 0, 15);
                    transform.rotation = Quaternion.Euler(-90, 0, 0);
                }
                else if (up && right && down)
                {
                    Mfilter.mesh = centerMesh[2];
                    Mcollider.sharedMesh = Mfilter.mesh;

                    transform.position = new Vector3(0, 0, 15);
                    transform.rotation = Quaternion.Euler(-90, 270, 0);
                }
                else if (up && left && down)
                {
                    Mfilter.mesh = centerMesh[2];
                    Mcollider.sharedMesh = Mfilter.mesh;

                    transform.position = new Vector3(0, 0, 15);
                    transform.rotation = Quaternion.Euler(-90, 90, 0);
                }
                else if (up && left && right)
                {
                    Mfilter.mesh = centerMesh[2];
                    Mcollider.sharedMesh = Mfilter.mesh;

                    transform.position = new Vector3(0, 0, 15);
                    transform.rotation = Quaternion.Euler(-90, 180, 0);
                }
                else if (up && down)
                {
                    int i = Random.Range(1, 3);

                    switch (i)
                    {
                        case 1:
                            Mfilter.mesh = centerMesh[0];
                            Mcollider.sharedMesh = Mfilter.mesh;

                            transform.position = new Vector3(0, 0, 15);
                            transform.rotation = Quaternion.Euler(-90, 180, 0);
                            break;

                        case 2:
                            Mfilter.mesh = centerMesh[1];
                            Mcollider.sharedMesh = Mfilter.mesh;

                            transform.position = new Vector3(0, 0, 15);
                            transform.rotation = Quaternion.Euler(-90, 180, 0);
                            break;
                    }

                }
                else if (left && right)
                {
                    int i = Random.Range(1, 3);

                    switch (i)
                    {
                        case 1:
                            Mfilter.mesh = centerMesh[0];
                            Mcollider.sharedMesh = Mfilter.mesh;

                            transform.position = new Vector3(0, 0, 15);
                            transform.rotation = Quaternion.Euler(-90, 90, 0);
                            break;

                        case 2:
                            Mfilter.mesh = centerMesh[1];
                            Mcollider.sharedMesh = Mfilter.mesh;

                            transform.position = new Vector3(0, 0, 15);
                            transform.rotation = Quaternion.Euler(-90, 90, 0);
                            break;
                    }
                }
                else if (up && left)
                {
                    Mfilter.mesh = centerMesh[6];
                    Mcollider.sharedMesh = Mfilter.mesh;

                    transform.position = new Vector3(0, 0, 15);
                    transform.rotation = Quaternion.Euler(-90, 90, 0);
                }
                else if (up && right)
                {
                    Mfilter.mesh = centerMesh[6];
                    Mcollider.sharedMesh = Mfilter.mesh;

                    transform.position = new Vector3(0, 0, 15);
                    transform.rotation = Quaternion.Euler(-90, 180, 0);
                }
                else if (down && left)
                {
                    Mfilter.mesh = centerMesh[6];
                    Mcollider.sharedMesh = Mfilter.mesh;

                    transform.position = new Vector3(0, 0, 15);
                    transform.rotation = Quaternion.Euler(-90, 0, 0);
                }
                else if (down && right)
                {
                    Mfilter.mesh = centerMesh[6];
                    Mcollider.sharedMesh = Mfilter.mesh;

                    transform.position = new Vector3(0, 0, 15);
                    transform.rotation = Quaternion.Euler(-90, 270, 0);
                }
                else
                {
                    Mfilter.mesh = centerMesh[7];
                    Mcollider.sharedMesh = Mfilter.mesh;

                    transform.position = new Vector3(0, 0, 15);
                    transform.rotation = Quaternion.Euler(-90, 270, 0);
                }

                break;
            case 8:
                i = Random.Range(1, 4);

                if (i == 0 || i == 1)
                {
                    
                    if (i == 0)
                    {
                        Mfilter.mesh = sideMesh[0];
                        Mcollider.sharedMesh = Mfilter.mesh;
                        MapManager.Instance.D = false;
                    }
                    else
                    {
                        Mfilter.mesh = sideMesh[1];
                        Mcollider.sharedMesh = Mfilter.mesh;
                        MapManager.Instance.D = false;
                    }

                    transform.position = new Vector3(-15, 0, 15);
                    transform.rotation = Quaternion.Euler(-90, 0, 0);
                }
                else
                {
                    MapManager.Instance.D = true;

                    Mfilter.mesh = sideMesh[2];
                    Mcollider.sharedMesh = Mfilter.mesh;

                    transform.position = new Vector3(-15, 0, 15);
                    transform.rotation = Quaternion.Euler(-90, 90, 0);
                }

                break;
            case 9:
                i = Random.Range(1, 4);


                if (i == 0 || i == 1)
                {
                    
                    if (i == 0)
                    {
                        Mfilter.mesh = sideMesh[0];
                        Mcollider.sharedMesh = Mfilter.mesh;
                        MapManager.Instance.E = false;
                    }
                    else
                    {
                        Mfilter.mesh = sideMesh[1];
                        Mcollider.sharedMesh = Mfilter.mesh;

                    }

                    transform.position = new Vector3(30, 0, 30);
                    transform.rotation = Quaternion.Euler(-90, 0, 0);
                }
                else
                {
                    MapManager.Instance.E = true;

                    Mfilter.mesh = sideMesh[2];
                    Mcollider.sharedMesh = Mfilter.mesh;

                    transform.position = new Vector3(30, 0, 30);
                    transform.rotation = Quaternion.Euler(-90, 270, 0);
                }

                break;
            case 10:

                up = MapManager.Instance.A;
                left = MapManager.Instance.E;
                right = MapManager.Instance.F;
                down = MapManager.Instance.G;


                if (up && left && right && down)
                {
                    i = Random.Range(3, 6);

                    Mfilter.mesh = centerMesh[i];
                    Mcollider.sharedMesh = Mfilter.mesh;

                    transform.position = new Vector3(15, 0, 30);
                    transform.rotation = Quaternion.Euler(-90, -90, 0);
                }
                else if (left && right && down)
                {

                    Mfilter.mesh = centerMesh[2];
                    Mcollider.sharedMesh = Mfilter.mesh;

                    transform.position = new Vector3(15, 0, 30);
                    transform.rotation = Quaternion.Euler(-90, 0, 0);
                }
                else if (up && right && down)
                {
                    Mfilter.mesh = centerMesh[2];
                    Mcollider.sharedMesh = Mfilter.mesh;

                    transform.position = new Vector3(15, 0, 30);
                    transform.rotation = Quaternion.Euler(-90, 270, 0);
                }
                else if (up && left && down)
                {
                    Mfilter.mesh = centerMesh[2];
                    Mcollider.sharedMesh = Mfilter.mesh;

                    transform.position = new Vector3(15, 0, 30);
                    transform.rotation = Quaternion.Euler(-90, 90, 0);
                }
                else if (up && left && right)
                {
                    Mfilter.mesh = centerMesh[2];
                    Mcollider.sharedMesh = Mfilter.mesh;

                    transform.position = new Vector3(15, 0, 30);
                    transform.rotation = Quaternion.Euler(-90, 180, 0);
                }
                else if (up && down)
                {
                    int i = Random.Range(1, 3);

                    switch (i)
                    {
                        case 1:
                            Mfilter.mesh = centerMesh[0];
                            Mcollider.sharedMesh = Mfilter.mesh;

                            transform.position = new Vector3(15, 0, 30);
                            transform.rotation = Quaternion.Euler(-90, 180, 0);
                            break;

                        case 2:
                            Mfilter.mesh = centerMesh[1];
                            Mcollider.sharedMesh = Mfilter.mesh;

                            transform.position = new Vector3(15, 0, 30);
                            transform.rotation = Quaternion.Euler(-90, 180, 0);
                            break;
                    }

                }
                else if (left && right)
                {
                    int i = Random.Range(1, 3);

                    switch (i)
                    {
                        case 1:
                            Mfilter.mesh = centerMesh[0];
                            Mcollider.sharedMesh = Mfilter.mesh;

                            transform.position = new Vector3(15, 0, 30);
                            transform.rotation = Quaternion.Euler(-90, 90, 0);
                            break;

                        case 2:
                            Mfilter.mesh = centerMesh[1];
                            Mcollider.sharedMesh = Mfilter.mesh;

                            transform.position = new Vector3(15, 0, 30);
                            transform.rotation = Quaternion.Euler(-90, 90, 0);
                            break;
                    }
                }
                else if (up && left)
                {
                    Mfilter.mesh = centerMesh[6];
                    Mcollider.sharedMesh = Mfilter.mesh;

                    transform.position = new Vector3(15, 0, 30);
                    transform.rotation = Quaternion.Euler(-90, 90, 0);
                }
                else if (up && right)
                {
                    Mfilter.mesh = centerMesh[6];
                    Mcollider.sharedMesh = Mfilter.mesh;

                    transform.position = new Vector3(15, 0, 30);
                    transform.rotation = Quaternion.Euler(-90, 180, 0);
                }
                else if (down && left)
                {
                    Mfilter.mesh = centerMesh[6];
                    Mcollider.sharedMesh = Mfilter.mesh;

                    transform.position = new Vector3(15, 0, 30);
                    transform.rotation = Quaternion.Euler(-90, 0, 0);
                }
                else if (down && right)
                {
                    Mfilter.mesh = centerMesh[6];
                    Mcollider.sharedMesh = Mfilter.mesh;

                    transform.position = new Vector3(15, 0, 30);
                    transform.rotation = Quaternion.Euler(-90, 270, 0);
                }
                else
                {
                    Mfilter.mesh = centerMesh[7];
                    Mcollider.sharedMesh = Mfilter.mesh;

                    transform.position = new Vector3(15, 0, 30);
                    transform.rotation = Quaternion.Euler(-90, 270, 0);
                }


                break;
            case 11:

                up = MapManager.Instance.B;
                left = MapManager.Instance.E;
                right = MapManager.Instance.F;
                down = MapManager.Instance.G;


                if (up && left && right && down)
                {
                    i = Random.Range(3, 6);

                    Mfilter.mesh = centerMesh[i];
                    Mcollider.sharedMesh = Mfilter.mesh;

                    transform.position = new Vector3(0, 0, 30);
                    transform.rotation = Quaternion.Euler(-90, -90, 0);
                }
                else if (left && right && down)
                {

                    Mfilter.mesh = centerMesh[2];
                    Mcollider.sharedMesh = Mfilter.mesh;

                    transform.position = new Vector3(0, 0, 30);
                    transform.rotation = Quaternion.Euler(-90, 0, 0);
                }
                else if (up && right && down)
                {
                    Mfilter.mesh = centerMesh[2];
                    Mcollider.sharedMesh = Mfilter.mesh;

                    transform.position = new Vector3(0, 0, 30);
                    transform.rotation = Quaternion.Euler(-90, 270, 0);
                }
                else if (up && left && down)
                {
                    Mfilter.mesh = centerMesh[2];
                    Mcollider.sharedMesh = Mfilter.mesh;

                    transform.position = new Vector3(0, 0, 30);
                    transform.rotation = Quaternion.Euler(-90, 90, 0);
                }
                else if (up && left && right)
                {
                    Mfilter.mesh = centerMesh[2];
                    Mcollider.sharedMesh = Mfilter.mesh;

                    transform.position = new Vector3(0, 0, 30);
                    transform.rotation = Quaternion.Euler(-90, 180, 0);
                }
                else if (up && down)
                {
                    int i = Random.Range(1, 3);

                    switch (i)
                    {
                        case 1:
                            Mfilter.mesh = centerMesh[0];
                            Mcollider.sharedMesh = Mfilter.mesh;

                            transform.position = new Vector3(0, 0, 30);
                            transform.rotation = Quaternion.Euler(-90, 180, 0);
                            break;

                        case 2:
                            Mfilter.mesh = centerMesh[1];
                            Mcollider.sharedMesh = Mfilter.mesh;

                            transform.position = new Vector3(0, 0, 30);
                            transform.rotation = Quaternion.Euler(-90, 180, 0);
                            break;
                    }

                }
                else if (left && right)
                {
                    int i = Random.Range(1, 3);

                    switch (i)
                    {
                        case 1:
                            Mfilter.mesh = centerMesh[0];
                            Mcollider.sharedMesh = Mfilter.mesh;

                            transform.position = new Vector3(0, 0, 30);
                            transform.rotation = Quaternion.Euler(-90, 90, 0);
                            break;

                        case 2:
                            Mfilter.mesh = centerMesh[1];
                            Mcollider.sharedMesh = Mfilter.mesh;

                            transform.position = new Vector3(0, 0, 30);
                            transform.rotation = Quaternion.Euler(-90, 90, 0);
                            break;
                    }
                }
                else if (up && left)
                {
                    Mfilter.mesh = centerMesh[6];
                    Mcollider.sharedMesh = Mfilter.mesh;

                    transform.position = new Vector3(0, 0, 30);
                    transform.rotation = Quaternion.Euler(-90, 90, 0);
                }
                else if (up && right)
                {
                    Mfilter.mesh = centerMesh[6];
                    Mcollider.sharedMesh = Mfilter.mesh;

                    transform.position = new Vector3(0, 0, 30);
                    transform.rotation = Quaternion.Euler(-90, 180, 0);
                }
                else if (down && left)
                {
                    Mfilter.mesh = centerMesh[6];
                    Mcollider.sharedMesh = Mfilter.mesh;

                    transform.position = new Vector3(0, 0, 30);
                    transform.rotation = Quaternion.Euler(-90, 0, 0);
                }
                else if (down && right)
                {
                    Mfilter.mesh = centerMesh[6];
                    Mcollider.sharedMesh = Mfilter.mesh;

                    transform.position = new Vector3(0, 0, 30);
                    transform.rotation = Quaternion.Euler(-90, 270, 0);
                }
                else
                {
                    Mfilter.mesh = centerMesh[7];
                    Mcollider.sharedMesh = Mfilter.mesh;

                    transform.position = new Vector3(0, 0, 30);
                    transform.rotation = Quaternion.Euler(-90, 270, 0);
                }

                break;

            case 12:
                    i = Random.Range(1, 4);

                    if (i == 0 || i == 1)
                    {
                    
                        if (i == 0)
                        {
                            Mfilter.mesh = sideMesh[0];
                            Mcollider.sharedMesh = Mfilter.mesh;
                             MapManager.Instance.F = false;
                        }
                        else
                        {
                            Mfilter.mesh = sideMesh[1];
                            Mcollider.sharedMesh = Mfilter.mesh;
                            MapManager.Instance.F = false;
                        }

                        transform.position = new Vector3(-15, 0, 30);
                        transform.rotation = Quaternion.Euler(-90, 0, 0);
                    }
                    else
                    {
                    MapManager.Instance.F = true;

                        Mfilter.mesh = sideMesh[2];
                        Mcollider.sharedMesh = Mfilter.mesh;

                        transform.position = new Vector3(-15, 0, 30);
                        transform.rotation = Quaternion.Euler(-90, 90, 0);
                    }

                break;
            case 13:
                Mfilter.mesh = cornerMesh[0];
                Mcollider.sharedMesh = Mfilter.mesh;
                transform.position = new Vector3(30, 0, 45);
                transform.rotation = Quaternion.Euler(-90, 180, 0);

                break;


            case 14:
                i = Random.Range(1, 4);


                if (i == 0 || i == 1)
                {
                    
                    if (i == 0)
                    {
                        Mfilter.mesh = sideMesh[0];
                        Mcollider.sharedMesh = Mfilter.mesh;
                        MapManager.Instance.G = false;
                    }
                    else
                    {
                        Mfilter.mesh = sideMesh[1];
                        Mcollider.sharedMesh = Mfilter.mesh;
                        MapManager.Instance.G = false;
                    }

                    transform.position = new Vector3(15, 0, 45);
                    transform.rotation = Quaternion.Euler(-90, 90, 0);
                }
                else
                {
                    MapManager.Instance.G = true;

                    Mfilter.mesh = sideMesh[2];
                    Mcollider.sharedMesh = Mfilter.mesh;

                    transform.position = new Vector3(15, 0, 45);
                    transform.rotation = Quaternion.Euler(-90, 180, 0);
                }

                break;

            case 15:
                i = Random.Range(1, 4);


                if (i == 0 || i == 1)
                {
                    
                    if (i == 0)
                    {
                        Mfilter.mesh = sideMesh[0];
                        Mcollider.sharedMesh = Mfilter.mesh;
                        MapManager.Instance.H = false;
                    }
                    else
                    {
                        Mfilter.mesh = sideMesh[1];
                        Mcollider.sharedMesh = Mfilter.mesh;
                        MapManager.Instance.H = false;
                    }

                    transform.position = new Vector3(0, 0, 45);
                    transform.rotation = Quaternion.Euler(-90, 90, 0);
                }
                else
                {
                    MapManager.Instance.H = true;

                    Mfilter.mesh = sideMesh[2];
                    Mcollider.sharedMesh = Mfilter.mesh;

                    transform.position = new Vector3(0, 0, 45);
                    transform.rotation = Quaternion.Euler(-90, 180, 0);
                }

                break;
            case 16:
                Mfilter.mesh = cornerMesh[0];
                Mcollider.sharedMesh = Mfilter.mesh;
                transform.position = new Vector3(-15, 0, 45);
                transform.rotation = Quaternion.Euler(-90, 90, 0);

                break;

        }
    }



}
