using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour {
    public GameObject menuholder;
    public GameObject settingmenuholder;
    public Slider[] VolumeSliders;
    public Toggle[] ScreenResolution;
  

    public void settingsmenu()
    {
        menuholder.SetActive(false);
        settingmenuholder.SetActive(true);
    }

    public void mainmenu()
    {
        menuholder.SetActive(true);
        settingmenuholder.SetActive(false);
    }

    public void setFullscreen(bool isFullscreen)
    {

    }
    public void setMasterVolume(float value)
    {
       // AudioManager.instance.SetVolume(value, AudioManager.AudioChannel.Master);
    }
    public void setMusicVolume(float value)
    {
      //  AudioManager.instance.SetVolume(value, AudioManager.AudioChannel.Music);
    }
    public void setSoundFXVolume(float value)
    {
      //  AudioManager.instance.SetVolume(value, AudioManager.AudioChannel.SoundFx);
    }


   


}
