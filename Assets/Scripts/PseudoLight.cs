using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PseudoLight : MonoBehaviour
{
    public int lightAngle = 20;
    public int lightBounds = 120;
    public float moveSpeed = 3;

    Transform leftFlank, rightFlank;
    float currentRotationZ;
    int bound;

    private void Start()
    {
        leftFlank = transform.GetChild(0);
        rightFlank = transform.GetChild(1);
        bound = lightBounds / 2;
    }

    private void Update()
    {
        SetupLight();
        MoveLight();
    }

    void SetupLight()
    {
        lightAngle = Mathf.Clamp(lightAngle, 0, 180);
        leftFlank.localRotation = Quaternion.Euler(0, 0, lightAngle / 2);
        rightFlank.localRotation = Quaternion.Euler(0, 0, 180 - lightAngle / 2);
    }

    void MoveLight()
    {
        float rotZ;
#if UNITY_EDITOR
        rotZ = Input.GetAxis("Horizontal");
#else
        rotZ = Input.acceleration.x * 2.5f;
#endif
        if ((rotZ < 0 && currentRotationZ < bound) || (rotZ > 0 && currentRotationZ > -bound))
            transform.rotation = Quaternion.Euler(0, 0, currentRotationZ += rotZ * -moveSpeed);
    }
}