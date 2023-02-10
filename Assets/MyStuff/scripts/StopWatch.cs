using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class StopWatch : MonoBehaviour
{
    #region singleton
    public static StopWatch instance;
    private void Awake()
    {
        if (instance == null)
            instance = this;
    }
    #endregion


    bool stopWatchActive = false;
    float CurrentTime;
    public TextMeshProUGUI currentTimeText;


    // Start is called before the first frame update
    void Start()
    {
        CurrentTime = 0;
        StartStopWatch();
    }

    // Update is called once per frame
    void Update()
    {
        if (stopWatchActive)
        {
            CurrentTime = CurrentTime + Time.deltaTime;
            
        }
        TimeSpan time = TimeSpan.FromSeconds(CurrentTime);
        currentTimeText.text = time.ToString(@"mm\:ss\:ff");

    }

    public void StartStopWatch()
    {
        stopWatchActive = true;
    }

    public void StopStopWatch()
    {
        stopWatchActive = false;
    }
}
