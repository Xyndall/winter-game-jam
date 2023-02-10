using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float mouseSensitivity = 100f;
    

    public Transform playerBody;
    float rotationX = 0;

    public GameObject Player = null;
    public GameObject fpsCam = null;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
            Cursor.lockState = CursorLockMode.None;


        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        rotationX -= mouseY;
        rotationX = Mathf.Clamp(rotationX, -90f, 90f);

        transform.localRotation = Quaternion.Euler(rotationX, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);
    }

    public void ChangeMouseSensitivity(float value)
    {
        mouseSensitivity = value * 100;
    }

    void OnGUI()
    {
        //Press this button to lock the Cursor
        if (GUI.Button(new Rect(0, 0, 100, 50), "Lock Cursor"))
        {
            Cursor.lockState = CursorLockMode.Locked;
        }

        //Press this button to confine the Cursor within the screen
        if (GUI.Button(new Rect(125, 0, 100, 50), "Confine Cursor"))
        {
            Cursor.lockState = CursorLockMode.Confined;
        }

        //Press this button to confine the Cursor within the screen
        if (GUI.Button(new Rect(250, 0, 150, 50), "Unlock cursor: Escape"))
        {
            Cursor.lockState = CursorLockMode.None;
        }
    }

}
