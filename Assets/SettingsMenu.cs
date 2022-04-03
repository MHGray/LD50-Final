using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SettingsMenu : MonoBehaviour
{

    [SerializeField] AudioMixer sfxMixer;
    [SerializeField] AudioMixer musicMixer;

    public void SetVolume(float vol)
    {
        //Change Volume here
        sfxMixer.SetFloat("Volume", Mathf.Log10(vol) * 80 - 80);
    }


    public void SetMusicVol(float vol)
    {
        //Change Music Vol
        musicMixer.SetFloat("Volume", Mathf.Log10(vol) * 80 - 80);
    }


}
