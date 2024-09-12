using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraController : MonoBehaviour
{
    Transform target;
    void Start()
    {
        target = GameObject.Find("Cube").transform;
    }

    void Update()
    {
        transform.LookAt(target);
    }
}
