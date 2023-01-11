using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.Events;
using UnityEngine.XR;
using Unity.VisualScripting;
using UnityEngine.AI;
using System.Text;
using UnityEngine.UI;

public class KickboardController : MonoBehaviour
{
    public KickBoardSO Data;
    public GameObject centerMess;
    public UnityEvent DeadEvent;
    public float CurrentBatteryState = 0;
    public bool isDead = false;
    private List<WheelCollider> wheelColliders = new List<WheelCollider>();
    private Rigidbody rb;

    public Slider BatterySlider;
    // Start is called before the first frame update
    void Start()
    {
        isDead = false;
        wheelColliders = GameObject.FindObjectsOfType<WheelCollider>().ToList();
        rb = GetComponent<Rigidbody>();
        BatterySlider = GameObject.FindObjectOfType<Slider>();
        rb.centerOfMass = centerMess.transform.localPosition;
        CurrentBatteryState = Data.BatterySize;
        BatterySlider.maxValue = Data.BatterySize;
        StartCoroutine(Battery());

        SetupVisual();
    }
    IEnumerator Battery()
    {
        while (!isDead)
        {
            if(CurrentBatteryState - Data.BatteryEfficiency*0.1f <= 0)
            {
                Dead();
            }
            CurrentBatteryState -= Data.BatteryEfficiency*0.1f;
            BatterySlider.value = CurrentBatteryState;
            yield return new WaitForSeconds(0.1f);
        }

        CurrentBatteryState = Mathf.Clamp(CurrentBatteryState, 0, Data.BatterySize);
        
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
            wheelColliders[i].brakeTorque = isDead ? 1000 : 0;  
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

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Map") && !isDead)
        {
            Dead();
        }
    }

    public void Dead()
    {
        BreakCapsule();
        DeadEvent?.Invoke();
        Debug.Log("너는 뒤졌다");
        isDead = true;
    }

    public void BreakCapsule()
    {
        GameObject character = GameObject.Find("Character");
        character.transform.parent = null;
        character.AddComponent<CapsuleCollider>();
        character.AddComponent<Rigidbody>();
        character.GetComponent<Rigidbody>().velocity *= 2;
    }
    public void SetupVisual()
    {
        List<Material> lst = new List<Material>();
        
        MeshRenderer[] mrs = gameObject.transform.GetComponentsInChildren<MeshRenderer>();

        mrs.ToList().ForEach(x =>
        {
            lst.Add(x.material); Debug.Log("히히");
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
