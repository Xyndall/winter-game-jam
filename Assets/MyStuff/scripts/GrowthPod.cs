using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrowthPod : MonoBehaviour
{
    public float GrowthAmount;

    Vector3 floatY;
    float originalY;

    float floatStrength = 1;

    void Start()
    {
        
        this.originalY = this.transform.position.y;
    }

    void Update()
    {
        transform.position = new Vector3(transform.position.x,
            originalY + ((float)Mathf.Sin(Time.time) * floatStrength),
            transform.position.z);
    }

}
