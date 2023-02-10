using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingCamera : MonoBehaviour
{
    Vector3 originalPos;

    // Start is called before the first frame update
    void Start()
    {
        originalPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(0,0,-20) * Time.deltaTime;

        if(transform.position.z <= -270.5)
        {
            transform.position = originalPos;
        }

    }
}
