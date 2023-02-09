using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public GameObject fpsCamera = null;

    public CharacterController controller;
    public Animator animator;

    Vector3 DefaultCharacterSize = new Vector3(1,1,1);
    public static float CharacterSize = 1;

    public float speed = 12;
    public float runSpeed = 20;
    public float normalSpeed = 12;
    public float gravity = -9.8f;

    public Vector3 velocity;

    public Vector3 move;


    public Transform GroundCheck;
    public float GroundDistance = 0.4f;
    public LayerMask GroundMask;

    public bool isGrounded;
    public float jumpHeight = 2f;

    void Start()
    {
        gameObject.transform.localScale = DefaultCharacterSize;
        animator.GetComponent<Animator>();
    }

    void Grow(float amount)
    {
        fpsCamera.transform.position += new Vector3(0, 0, -0.02f);
        CharacterSize += amount;
        gameObject.transform.localScale += new Vector3(amount,amount,amount);
    }

    void Shrink(){

    }

    // Update is called once per frame
    void Update()
    {

        

        fpsCamera.GetComponentInChildren<Camera>().fieldOfView = 80;

        isGrounded = Physics.CheckSphere(GroundCheck.position, GroundDistance, GroundMask);

        if(isGrounded) 
            animator.SetBool("Grounded", true);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = 0f;
            
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        move = transform.right * x + transform.forward * z;

        if (!isGrounded)
        {
            velocity.y += gravity * Time.deltaTime;
        }

        controller.Move(move * speed * Time.deltaTime);

        controller.Move(velocity * Time.deltaTime);

        if (z > 0 || z < 0)
        {
            animator.SetBool("isMoving", true);

        }
        else
        {
            animator.SetBool("isMoving", false);
        }
        
        animator.SetFloat("MovingFloat", z);

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            animator.SetTrigger("Jump");
        }


        if (Input.GetKey(KeyCode.LeftShift))
        {

                
                animator.SetBool("Sprint", true);
                fpsCamera.GetComponentInChildren<Camera>().fieldOfView = Mathf.Lerp(80, 85, 1);
                speed = runSpeed;
  
        }
        else
        {
            
            
            animator.SetBool("Sprint", false);
            speed = normalSpeed;
        }
    }

    private void OnTriggerEnter(Collider other) {
        if(other.CompareTag("GrowthPod"))
        {
            Grow(other.GetComponent<GrowthPod>().GrowthAmount);
            Destroy(other.gameObject);
            Debug.Log($"growthpod touched");
        }
    }

}
