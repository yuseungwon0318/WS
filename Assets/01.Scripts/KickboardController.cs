using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.XR;
using Unity.VisualScripting;
using UnityEngine.AI;
using System.Text;

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

        SetupVisual();
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
    
    public void SetupVisual()
    {
        List<Material> lst = new List<Material>();
        
        MeshRenderer[] mrs = gameObject.transform.GetComponentsInChildren<MeshRenderer>();

        mrs.ToList().ForEach(x =>
        {
            lst.Add(x.material); Debug.Log("È÷È÷");
        });

        lst.ForEach(x =>
        {
            string[] names = x.name.Split(" (Instance)");
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < names.Length; i++)
            {
                sb.Append(names[i]);
            }
            string name = sb.ToString();
            switch (name)
            {
                case "Battery Case":
                    x.color = Data.BatteryCase;
                    break;
                case "Battery Cover":
                    x.color = Data.BatteryCover;
                    break;
                case "Front Axle":
                    x.color = Data.FrontAxle;
                    break;
                case "Handle Bar":
                    x.color = Data.HandleBar;
                    break;
                case "Handle Bar Extra":
                    x.color = Data.HandleBarExtra;
                    break;
                case "Handle Center":
                    x.color = Data.HandleCenter;
                    break;
                case "Rear Axle":
                    x.color = Data.RearAxle;
                    break;
                case "Rear Wheel Cover":
                    x.color = Data.RearWheelCover;
                    break;
                case "Steer Rod":
                    x.color = Data.SteerRod;
                    break;
                case "Steer Supporter":
                    x.color = Data.SteerSupporter;
                    break;
                default:
                    Debug.LogError("tlqkf");
                    break;
            }
        });
    }
}
