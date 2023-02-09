using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DoorCheckSize : MonoBehaviour
{
    public GameObject doorCollider;
    public GameObject doorTextObj;

    public TextMeshProUGUI doorText;

    public float DoorSize;

    // Start is called before the first frame update
    void Start()
    {
        doorCollider.SetActive(true);
        doorTextObj.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        doorText.text = "Size Needed: " + DoorSize;

    }

    
    private void OnTriggerStay(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            if(Movement.CharacterSize >= DoorSize)
            {
                doorCollider.SetActive(false);
                doorTextObj.SetActive(false);
            }
            
        }
    }
}
