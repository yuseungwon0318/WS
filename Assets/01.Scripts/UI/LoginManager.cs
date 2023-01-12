using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoginManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GPGSBinder.Inst.Login();
    }

    
}
