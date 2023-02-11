using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeController : MonoBehaviour
{

    public AudioSource musicSource;
    public AudioMixer SFXSource;

    public Toggle musictoggle;
    public Toggle SFXtoggle;
    bool musicMuted;
    bool SFXMuted;
    private void OnEnable()
    {
        musictoggle.GetComponent<Toggle>();
        SFXtoggle.GetComponent<Toggle>();
        
    }

    private void Update()
    {
        musicMuted = musictoggle.isOn;
        if (musicMuted)
        {
            musicSource.Pause();
        }
        else
        {
            musicSource.UnPause();
        }

        SFXMuted = SFXtoggle.isOn;
        if (SFXMuted)
        {
            SFXSource.SetFloat("SFXVolume", -80);
        }
        else
        {
            SFXSource.SetFloat("SFXVolume", 0);
        }
    }

    public void MuteMusic(bool muted)
    {
        Debug.Log(muted);
        
        
    }

    public void MuteSFX(bool muted)
    {
        if (muted)
        {
            SFXSource.SetFloat("SFXVolume", 0);
        }
        else
        {
            SFXSource.SetFloat("SFXVolume", 80);
        }

    }
}
