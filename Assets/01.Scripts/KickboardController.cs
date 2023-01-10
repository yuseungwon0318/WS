using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.XR;
using Unity.VisualScripting;
using UnityEngine.AI;

public class KickboardController : MonoBehaviour
{
    public KickBoardSO Data;
    public GameObject centerMess;

    public int CurrentBatteryState = 0;
    public bool isDead = false;
    private List<WheelCollider> wheelColliders = new List<WheelCollider>();
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        isDead = false;
        wheelColliders = GameObject.FindObjectsOfType<WheelCollider>().ToList();
        rb = GetComponent<Rigidbody>();
        rb.centerOfMass = centerMess.transform.localPosition;
        CurrentBatteryState = Data.BatterySize;

        StartCoroutine(Battery());
    }
    IEnumerator Battery()
    {
        while (!isDead)
        {
            if(CurrentBatteryState - Data.BatteryEfficiency <= 0)
            {
                isDead =true;
            }
            CurrentBatteryState -= Data.BatteryEfficiency;
            yield return new WaitForSeconds(1f);
        }

    }
    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            //StartCoroutine(JumpSide360());
        }
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            //StartCoroutine(JumpFront360());
        }


    }

    public void Move(float vertical, float horizontal)
    {


        wheelColliders.Where(x => x.name == "F").ToList().ForEach(z =>
        {
            if (horizontal != 0)
            {
                z.steerAngle += horizontal;
            }
            else
            {
                z.steerAngle = 0;
            }
            z.steerAngle = Mathf.Clamp(z.steerAngle, -Data.SteerAngle, Data.SteerAngle);
        });


        for (int i = 0; i < wheelColliders.Count; i++)
        {
            wheelColliders[i].motorTorque = isDead ? 0 : vertical * Data.Power;
        }
    }
    void FixedUpdate()
    {
        //transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, transform.localEulerAngles.y, 0);
    }
    IEnumerator JumpSide360()
    {
        rb.AddForce(Vector3.up * 400, ForceMode.Acceleration);
        yield return null;
        rb.AddTorque(Vector3.up*5000);
    }
    IEnumerator JumpFront360()
    {
        rb.AddForce(Vector3.up * 400, ForceMode.Acceleration);
        yield return null;
        rb.AddTorque(Vector3.left * 6000);
    }
    
}
