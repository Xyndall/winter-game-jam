using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject pauseScreen;
    bool isPaused;

    // Start is called before the first frame update
    void Start()
    {
        pauseScreen.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                //close inventory
                ResumeGame();

            }
            else
            {
                //openInventory
                PauseGame();


            }

            
        }


    }

    public void PauseGame()
    {
        isPaused = true;
        Time.timeScale = 0;
        pauseScreen.gameObject.SetActive(true);
    }
    public void ResumeGame()
    {
        isPaused = false;
        Time.timeScale = 1;
        pauseScreen.gameObject.SetActive(false);
    }


}
