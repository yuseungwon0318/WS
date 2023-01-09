using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Kickboard")]
public class KickBoardSO : ScriptableObject
{
    public string Name;
    [Multiline(5)]
    public string Description;

    public float Power;
    public float SteerAngle;
    public float Battery;
}
