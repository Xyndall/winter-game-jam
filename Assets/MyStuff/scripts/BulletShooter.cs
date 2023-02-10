using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletShooter : MonoBehaviour
{
    public GameObject bullet;
    public Transform bulletSpawn;

    public float fireRate = 0.5F;
    private float nextFire = 0.0F;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            GameObject clone = Instantiate(bullet, bulletSpawn.position, Quaternion.Euler(0,180,0));
        }
        


    }
}
