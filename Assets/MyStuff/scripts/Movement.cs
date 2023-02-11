using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Movement : MonoBehaviour
{
    #region singleton
    public static Movement instance;
    private void Awake()
    {
        if (instance == null)
            instance = this;
    }
    #endregion

    public GameObject fpsCamera = null;

    public CharacterController controller;
    public GameObject newCamera;

    Vector3 DefaultCharacterSize = new Vector3(1, 1, 1);
    Vector3 newCharacterSize = new Vector3(1, 1, 1);
    public static float CharacterSize = 1;
    public float MaxCaharcterSize;
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

    public AudioSource aSource;
    public AudioClip[] aClip;

    void Start()
    {
        aSource.GetComponent<AudioSource>();
        defCaharcterSize = 1;
        CharacterSize = 1;
        gameObject.transform.localScale = DefaultCharacterSize;
    }

    void Grow(float amount)
    {

        jumpHeight += 0.2f;
        newJumpHeight = jumpHeight;
        CharacterSize += 1;
        baseCharacterSize += 1;
        MaxCaharcterSize = baseCharacterSize;
        gameObject.transform.localScale += new Vector3(amount,amount,amount);
        newCharacterSize += new Vector3(amount, amount, amount);
    }

    void Shrink()
    {
        PlaySounds(aClip[2]);
        isShrunk = true;
        jumpHeight = DefaultJumpHeight;
        gameObject.transform.localScale = DefaultCharacterSize;
        CharacterSize = defCaharcterSize;

    }

    void UnShrink()
    {
        PlaySounds(aClip[3]);
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
            PlaySounds(aClip[1]);
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

    public void PlaySounds(AudioClip clip)
    {
        aSource.PlayOneShot(clip);
    }

    private void OnTriggerEnter(Collider other) {
        if(other.CompareTag("GrowthPod"))
        {
            PlaySounds(aClip[0]);
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
        if (other.CompareTag("Win"))
        {
            GameManager.instance.ShowWinScreen();
        }
        if (other.CompareTag("Respawn"))
        {
            transform.position = new Vector3(0, 0, -180);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(GroundCheck.position, GroundDistance);
    }

}
