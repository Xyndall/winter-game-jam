using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public GameObject fpsCamera = null;

    public CharacterController controller;

    public float speed = 12;
    public float runSpeed = 20;
    public float normalSpeed = 12;
    public float gravity = -9.8f;
    

    bool sprinting = false;

    public Vector3 velocity;


    public Transform GroundCheck;
    public float GroundDistance = 0.4f;
    public LayerMask GroundMask;

    public bool isGrounded;
    public float jumpHeight = 2f;


    // Update is called once per frame
    void Update()
    {
        fpsCamera.GetComponentInChildren<Camera>().fieldOfView = 80;

        isGrounded = Physics.CheckSphere(GroundCheck.position, GroundDistance, GroundMask);

        if(isGrounded && velocity.y < 0)
        {
            velocity.y = 0f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        if (!isGrounded)
        {
            velocity.y += gravity * Time.deltaTime;
        }

        controller.Move(move * speed * Time.deltaTime);

        controller.Move(velocity * Time.deltaTime);


        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            
        }


        if (Input.GetKey(KeyCode.LeftShift))
        {

                sprinting = true;
                
                fpsCamera.GetComponentInChildren<Camera>().fieldOfView = Mathf.Lerp(80, 85, 1);
                speed = runSpeed;
  
        }
        else
        {
            
            sprinting = false;
            speed = normalSpeed;
        }
    }



}
