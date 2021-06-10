using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotateYAxis : MonoBehaviour
{

    [SerializeField] float rotSpeed = 100f;
    // Update is called once per frame
    void FixedUpdate()
    {
        transform.RotateAround(transform.position, transform.up, Time.deltaTime * rotSpeed);
    }
}
