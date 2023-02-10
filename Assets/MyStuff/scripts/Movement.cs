using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Movement : MonoBehaviour
{
    public GameObject fpsCamera = null;

    public CharacterController controller;
    public GameObject newCamera;

    Vector3 DefaultCharacterSize = new Vector3(1,1,1);
    Vector3 newCharacterSize = new Vector3(1, 1, 1);
    public static float CharacterSize = 1;
    float MaxCaharcterSize;
    float defCaharcterSize = 1;
    float baseCharacterSize = 1;
    

    public float speed = 12;
    public float runSpeed = 20;
    public float normalSpeed = 12;
    public float gravity = -9.8f;

    public Vector3 velocity;

    public Vector3 move;


    public Transform GroundCheck;
    public float GroundDistance = 0.8f;
    public LayerMask GroundMask;

    public bool isGrounded;
    float newJumpHeight;
    float jumpHeight = 1.5f;
    float DefaultJumpHeight = 1.5f;
    bool jumped;

    bool isShrunk;

    void Start()
    {
        defCaharcterSize = 1;
        CharacterSize = 1;
        gameObject.transform.localScale = DefaultCharacterSize;
    }

    void Grow(float amount)
    {

        jumpHeight += 0.1f;
        newJumpHeight = jumpHeight;
        CharacterSize += amount;
        baseCharacterSize += amount;
        MaxCaharcterSize = baseCharacterSize;
        gameObject.transform.localScale += new Vector3(amount,amount,amount);
        newCharacterSize += new Vector3(amount, amount, amount);
    }

    void Shrink()
    {
        isShrunk = true;
        jumpHeight = DefaultJumpHeight;
        gameObject.transform.localScale = DefaultCharacterSize;
        CharacterSize = defCaharcterSize;

    }

    void UnShrink()
    {
        isShrunk = false;
        jumpHeight = newJumpHeight;
        gameObject.transform.localScale = newCharacterSize;
        CharacterSize = MaxCaharcterSize;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && isShrunk == false)
        {
            Shrink();
        }
        if (Input.GetKeyDown(KeyCode.R) && isShrunk == true)
        {
            UnShrink();
        }

        fpsCamera.GetComponentInChildren<Camera>().fieldOfView = 80;

        isGrounded = Physics.CheckSphere(GroundCheck.position, GroundDistance, GroundMask);

        if (isGrounded)
            jumped = false;

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
        
        

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded && !jumped)
        {
            jumped = true;
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            
        }


        if (Input.GetKey(KeyCode.LeftShift))
        {
                
                fpsCamera.GetComponentInChildren<Camera>().fieldOfView = Mathf.Lerp(80, 85, 1);
                speed = runSpeed;
  
        }
        else
        {
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
        if (other.CompareTag("Bullet"))
        {
            Destroy(gameObject);
            Instantiate(newCamera, transform.position, transform.rotation);
            GameManager.instance.ShowDeathScreen();
        }

    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(GroundCheck.position, GroundDistance);
    }

}
