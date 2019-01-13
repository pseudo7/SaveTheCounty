using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moon : MonoBehaviour
{
    public bool local;
    public float rotationSpeed = 2;
    public Vector3 rotationAngle;

    private void Start()
    {
        transform.Rotate(rotationAngle * Random.Range(0, 360), local ? Space.Self : Space.World);
    }

    void Update()
    {
        transform.Rotate(rotationAngle * rotationSpeed * Time.deltaTime, local ? Space.Self : Space.World);
    }
}
