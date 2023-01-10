using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Kickboard")]
public class KickBoardSO : ScriptableObject
{
    [Header("Info")]
    public string Name;
    [Multiline(5)]
    public string Description;

    [Header("Performance")]
    public float Power; 
    public float SteerAngle;
    public int BatterySize;
    [Tooltip("1ÃÊ¿¡ ´â´Â ¾ç\nLower is better")]
    public int BatteryEfficiency;

    [Header("Visual")]
    public Color BatteryCase;
    public Color BatteryCover;
    public Color FrontAxle;
}
