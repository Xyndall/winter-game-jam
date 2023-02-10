using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletTravel : MonoBehaviour
{
    public Vector3 userDirection = Vector3.right;
    bool travel;

    private void Start()
    {
        
        Destroy(gameObject, 10);
    }

    // Update is called once per frame
    void Update()
    {
            transform.Translate(userDirection * 5 * Time.deltaTime);


    }

    

}
