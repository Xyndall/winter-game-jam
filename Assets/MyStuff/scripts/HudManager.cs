using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HudManager : MonoBehaviour
{
    public TextMeshProUGUI sizeText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        string vOut = Movement.CharacterSize.ToString();
        sizeText.text = "Current Size: " + vOut;

    }
}
