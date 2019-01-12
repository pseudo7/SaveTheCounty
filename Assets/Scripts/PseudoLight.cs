using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PseudoLight : MonoBehaviour
{
    public int lightAngle = 20;
    public int lightBounds = 120;

    Transform leftFlank, rightFlank;
    Quaternion leftFlankRotation, rightFlankRotation;

    private void Start()
    {
        leftFlank = transform.GetChild(0);
        rightFlank = transform.GetChild(1);
    }

    private void Update()
    {
        lightAngle = Mathf.Clamp(lightAngle, 0, 180);
        leftFlank.localRotation = Quaternion.Euler(0, 0, lightAngle / 2);
        rightFlank.localRotation = Quaternion.Euler(0, 0, 180 - lightAngle / 2);
    }
}
