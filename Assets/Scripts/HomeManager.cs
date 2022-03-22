using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine.UI;
public class HomeManager : MonoBehaviour
{
    public AudioMixer mixer;
    public Slider sliderBGM;
    public Slider sliderSFX;

    private void Start() {
        LoadVolumeSetting();
    }

    void LoadVolumeSetting(){
        if(PlayerPrefs.HasKey("BGM_VOL")){
            float bgmVol = PlayerPrefs.GetFloat("BGM_VOL");
            SetBGM(bgmVol);
            sliderBGM.value = bgmVol;
        }
        if(PlayerPrefs.HasKey("SFX_VOL")){
            float sfxVol = PlayerPrefs.GetFloat("SFX_VOL");
            SetBGM(sfxVol);
            sliderSFX.value = sfxVol;
        }
    }

    public void SetBGM(float vol){
        if(mixer != null){
            mixer.SetFloat("BGM_VOL", vol);
            PlayerPrefs.SetFloat("BGM_VOL", vol);
        }
    }
    public void SetSFX(float vol){
        if(mixer != null){
            mixer.SetFloat("SFX_VOL", vol);
            PlayerPrefs.SetFloat("SFX_VOL", vol);
        }
    }
    public void PlaySuperBird(){
        SceneManager.LoadScene("SuperBird_play");
    }

    public void PlayOtherScene(string sceneName){
        SceneManager.LoadScene(sceneName);
    }
}
