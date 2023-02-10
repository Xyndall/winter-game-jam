using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveingPlatforms : MonoBehaviour
{
    [SerializeField] Transform _destination;
    Vector3 OriginalPos;
    bool goingToDestination = false;

    private void Start()
    {
        OriginalPos = transform.position;
    }

    void Update()
    {
        float Step = 2.5f * Time.deltaTime;
        
       

        if(goingToDestination == true)
        {
            
            transform.position = Vector3.MoveTowards(transform.position, _destination.position, Step);
        }
            

        if (Vector3.Distance(transform.position, _destination.position) < 0.001f)
        {
            goingToDestination = false;
            transform.position = Vector3.MoveTowards(_destination.position, transform.position, Step);
        }

        if(Vector3.Distance(transform.position, OriginalPos) < 0.001f)
        {
            goingToDestination = true;
        }
    }
}
