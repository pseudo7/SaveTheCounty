using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PseudoLight : MonoBehaviour
{
    public int lightAngle = 20;
    public int lightBounds = 120;
    public float moveSpeed = 10;

    Transform leftFlank, rightFlank;

    private void Start()
    {
        leftFlank = transform.GetChild(0);
        rightFlank = transform.GetChild(1);
    }

    private void Update()
    {
        SetupLight();
    }

    void SetupLight()
    {
        lightAngle = Mathf.Clamp(lightAngle, 0, 180);
        leftFlank.localRotation = Quaternion.Euler(0, 0, lightAngle / 2);
        rightFlank.localRotation = Quaternion.Euler(0, 0, 180 - lightAngle / 2);
    }

    void MoveLight()
    {
#if UNITY_EDITOR
        transform.Rotate(0, 0, Time.deltaTime * moveSpeed)
#endif
    }
}
