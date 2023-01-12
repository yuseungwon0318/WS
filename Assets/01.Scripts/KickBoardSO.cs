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
    public int Price;

    [Header("Performance")]
    public float Power; 
    public float SteerAngle;
    public int BatterySize;
    [Tooltip("1ÃÊ¿¡ ´â´Â ¾ç\nLower is better")]
    public int BatteryEfficiency;

    [Header("Visual")]
    [ColorUsage(false)]
    public Color BatteryCase;
    [ColorUsage(false)]
    public Color BatteryCover;
    [ColorUsage(false)]
    public Color FrontAxle;
    [ColorUsage(false)]
    public Color HandleBar;
    [ColorUsage(false)]
    public Color HandleBarExtra;
    [ColorUsage(false)]
    public Color HandleCenter;
    [ColorUsage(false)]
    public Color RearAxle;
    [ColorUsage(false)]
    public Color RearWheelCover;
    [ColorUsage(false)]
    public Color SteerRod;
    [ColorUsage(false)]
    public Color SteerSupporter;
}
