using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Kickboard")]
public class KickBoardSO : ScriptableObject
{
    public string Name;
    [Multiline(5)]
    public string Description;

    [Header("Performance")]
    public float Power; 
    public float SteerAngle;
    [Tooltip("1초에 얼마")]
    public float BatteryEfficiency;
    public float BatterySize;
}
