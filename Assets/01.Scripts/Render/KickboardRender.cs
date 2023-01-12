using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class KickboardRender : MonoBehaviour
{
    public KickBoardSO Data;


    private void Start()
    {
        SetupVisual();
    }
    private void Update()
    {
        transform.localEulerAngles += new Vector3(0, 0.5f, 0);
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
