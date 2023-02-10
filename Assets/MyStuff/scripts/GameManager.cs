using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class GameManager : MonoBehaviour
{
    #region singleton
    public static GameManager instance;
    private void Awake()
    {
        if (instance == null)
            instance = this;
    }
    #endregion

    public TextMeshProUGUI sizeText;
    public TextMeshProUGUI timeText;

    public GameObject pauseScreen;
    public GameObject StartScreen;
    public GameObject DeathScreen;
    public GameObject winScreen;
    bool isPaused;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0;
        StartScreen.gameObject.SetActive(true);
        pauseScreen.gameObject.SetActive(false);
        DeathScreen.gameObject.SetActive(false);
        winScreen.gameObject.SetActive(false);
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


        if (Input.GetKeyDown(KeyCode.F))
        {
            StartGame();
        }

    }

    public void PauseGame()
    {
        isPaused = true;
        Time.timeScale = 0;
        pauseScreen.gameObject.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
    }
    public void ResumeGame()
    {
        isPaused = false;
        Time.timeScale = 1;
        pauseScreen.gameObject.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
    }


    public void ShowDeathScreen()
    {
        sizeText.text = "SIZE: " + Movement.instance.MaxCaharcterSize.ToString();
        Cursor.lockState = CursorLockMode.None;
        DeathScreen.gameObject.SetActive(true);
        Time.timeScale = 0;

    }

    public void ShowWinScreen()
    {
        TimeSpan time = TimeSpan.FromSeconds(StopWatch.instance.CurrentTime);
        timeText.text = time.ToString(@"mm\:ss\:ff");

        sizeText.text = "SIZE: " + Movement.instance.MaxCaharcterSize.ToString();

        Cursor.lockState = CursorLockMode.None;
        winScreen.gameObject.SetActive(true);
        

    }

    public void StartGame()
    {
        Time.timeScale = 1;
        StartScreen.gameObject.SetActive(false);
        StopWatch.instance.StartStopWatch();
        Cursor.lockState = CursorLockMode.Locked;
    }

}
