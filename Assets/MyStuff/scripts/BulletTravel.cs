using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletTravel : MonoBehaviour
{
    public Vector3 userDirection = Vector3.right;
    bool travel;

    private void Start()
    {
        StartCoroutine(DestroyBullet());
    }

    // Update is called once per frame
    void Update()
    {
        while(travel)
            transform.Translate(userDirection * 5 * Time.deltaTime);


    }
    IEnumerator DestroyBullet()
    {
        travel = true;
        yield return new WaitForSeconds(10);
        travel = false;
        Destroy(gameObject);

    }

}
