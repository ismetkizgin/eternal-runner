using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class buttonFunction : MonoBehaviour
{
    /*
    Burdaki kodlar HomeScreen, CharacterSelectionScreen ve SettingScreen de kullanılmakta.
    */
    public GameObject settingscreen;
    public GameObject mainscreen;
    public GameObject characterselectionscreen;
    Image _ajbuttonimage,_amybuttonimage; 
    public int character; //0->Amy, 1->Aj
    public GameObject amybutton, ajbutton;
    [SerializeField] Color characterselectionactivecolor, characterselectiondefaultcolor;
    [SerializeField] RectTransform musicuihandlerecttransform, sounduihandlerecttransform;
    [SerializeField] Color backgroundactivecolor;
    [SerializeField] Color handleactivecolor;
    Image _musicBackgroundImage, _musicHandleImage, _soundBackgroundImage, _soundHandleImage;
    Color _musicBackgroundDefaultColor, _musicHandleDefaultColor, _soundBackgroundDefaultColor, _soundHandleDefaultColor;
    Toggle _musicToggle, _soundToggle;
    Vector2 _musicHandlePosition, _soundHandlePosition;
    public int musicentry, soundentry;
    public GameObject musicswitchtoggle, soundswitchtoggle;
    public AudioSource music;

    private void Awake(){
        HomeScreen();

        _musicToggle = musicswitchtoggle.GetComponent <Toggle> ();
        _musicHandlePosition = musicuihandlerecttransform.anchoredPosition;

        _musicBackgroundImage = musicuihandlerecttransform.parent.GetComponent <Image>();
        _musicHandleImage = musicuihandlerecttransform.GetComponent <Image> ();

        _musicBackgroundDefaultColor = _musicBackgroundImage.color;
        _musicHandleDefaultColor = _musicHandleImage.color;

        _ajbuttonimage = ajbutton.GetComponent<Image>();
        _amybuttonimage = amybutton.GetComponent<Image>();

        _soundToggle = soundswitchtoggle.GetComponent <Toggle> ();
        _soundHandlePosition = sounduihandlerecttransform.anchoredPosition;

        _soundBackgroundImage = sounduihandlerecttransform.parent.GetComponent <Image>();
        _soundHandleImage = sounduihandlerecttransform.GetComponent <Image> ();

        _soundBackgroundDefaultColor = _soundBackgroundImage.color;
        _soundHandleDefaultColor = _soundHandleImage.color;

        if(!PlayerPrefs.HasKey("character")){
            PlayerPrefs.SetInt("character",1);
            CharacterLoad();
        }
        else{
            CharacterLoad();
        }

        if(!PlayerPrefs.HasKey("musicentry"))
        {
            PlayerPrefs.SetInt("musicentry",1);
            MusicLoad();
        }
        else
        {
            MusicLoad();
        }

        if(!PlayerPrefs.HasKey("soundentry"))
        {
            PlayerPrefs.SetInt("soundentry",1);
            SoundLoad();
        }
        else
        {
            SoundLoad();
        }

    }

    public void Play(){
        SceneManager.LoadScene("SahneGame");//Oyun Sahnesine Geçiş
    }

    public void Settings(){
        mainscreen.SetActive(false);
        settingscreen.SetActive(true);
    }

    public void CharacterSelection(){
        mainscreen.SetActive(false);
        characterselectionscreen.SetActive(true);
    }

    public void HomeScreen(){
        settingscreen.SetActive(false);
        characterselectionscreen.SetActive(false);
        mainscreen.SetActive(true);
    }

    void CharacterLoad(){
        if(PlayerPrefs.GetInt("character") == 1){
            AjButtonClick();
        }
        else{
            AmyButtonClick();
        }
    }

    public void AjButtonClick(){
        _ajbuttonimage.color = characterselectionactivecolor;
        _amybuttonimage.color = characterselectiondefaultcolor;

        PlayerPrefs.SetInt("character",1);
        character = 1;
    }

    public void AmyButtonClick(){
        _amybuttonimage.color = characterselectionactivecolor;
        _ajbuttonimage.color = characterselectiondefaultcolor;

        PlayerPrefs.SetInt("character",0);
        character = 0;
    }

    public void MusicOnSwitch(bool on)
    {
        musicuihandlerecttransform.anchoredPosition = on ? _musicHandlePosition * -1 : _musicHandlePosition;
        _musicBackgroundImage.color = on ? backgroundactivecolor : _musicBackgroundDefaultColor;
        _musicHandleImage.color = on ? handleactivecolor : _musicHandleDefaultColor;
    }

    public void SoundOnSwitch(bool on)
    {
        sounduihandlerecttransform.anchoredPosition = on ? _soundHandlePosition * -1 : _soundHandlePosition;
        _soundBackgroundImage.color = on ? backgroundactivecolor : _soundBackgroundDefaultColor;
        _soundHandleImage.color = on ? handleactivecolor : _soundHandleDefaultColor;
    }

    public void MusicLoad()
    {
        if(PlayerPrefs.GetInt("musicentry") == 0)
        {
            musicentry = 0;
            _musicToggle.isOn = false;
            MusicOnSwitch(false);
            music.Pause();
        }
        else
        {
            musicentry = 1;
            _musicToggle.isOn = true;
            MusicOnSwitch(true);
            music.Play();
        }
    }

     public void ChangeMusic()
    {
        if(_musicToggle.isOn)
        {
            musicentry = 1;
            PlayerPrefs.SetInt("musicentry",1);
            MusicOnSwitch(true);
            music.Play();
        }
        else
        {
            musicentry = 0;
            PlayerPrefs.SetInt("musicentry",0);
            MusicOnSwitch(false);
            music.Pause();
        }
    }

    public void SoundLoad()
    {
        if(PlayerPrefs.GetInt("soundentry") == 0)
        {
            soundentry = 0;
            _soundToggle.isOn = false;
            SoundOnSwitch(false);
        }
        else
        {
            soundentry = 1;
            _soundToggle.isOn = true;
            SoundOnSwitch(true);
        }
    }

    public void ChangeSound()
    {
        //AudioListener.pause = toggle.isOn;
        if(_soundToggle.isOn)
        {
            soundentry = 1;
            PlayerPrefs.SetInt("soundentry",1);
            SoundOnSwitch(true);
        }
        else
        {
            soundentry = 0;
            PlayerPrefs.SetInt("soundentry",0);
            SoundOnSwitch(false);
        }
    }
}
