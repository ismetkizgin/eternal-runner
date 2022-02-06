using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class musicSwitchToggle : MonoBehaviour
{
    [SerializeField] RectTransform uihandlerecttransform;//[SerializeField] ile Public aynı mantık
    [SerializeField] Color backgroundactivecolor;
    [SerializeField] Color handleactivecolor;
    Image _backgroundImage, _handleImage;
    Color _backgroundDefaultColor, _handleDefaultColor;
    Toggle _toggle;
    Vector2 _handlePosition;
    public int musicentry;
    public GameObject musicswitchtoggle;
    public AudioSource music;


    void Awake()
    {
        _toggle = musicswitchtoggle.GetComponent <Toggle> ();
        _handlePosition = uihandlerecttransform.anchoredPosition; //canvastaki anchored pozisyonuna erişiyor

        _backgroundImage = uihandlerecttransform.parent.GetComponent <Image>();
        _handleImage = uihandlerecttransform.GetComponent <Image> ();

        _backgroundDefaultColor = _backgroundImage.color;
        _handleDefaultColor = _handleImage.color;

        if(!PlayerPrefs.HasKey("musicentry"))
        {
            PlayerPrefs.SetInt("musicentry",1);
            Load();
        }
        else
        {
            Load();
        }
   }
    public void OnSwitch(bool on)
    {
        uihandlerecttransform.anchoredPosition = on ? _handlePosition * -1 : _handlePosition;
        _backgroundImage.color = on ? backgroundactivecolor : _backgroundDefaultColor;
        _handleImage.color = on ? handleactivecolor : _handleDefaultColor;
    }

    public void ChangeMusic()
    {
        Save();
        if(_toggle.isOn)
        {
            OnSwitch(true);
            music.Play();
        }
        else
        {
            OnSwitch(false);
            music.Pause();
        }
    }
    public void Load()
    {
        if(PlayerPrefs.GetInt("musicentry") == 0)
        {
            musicentry = 0;
            _toggle.isOn = false;
            OnSwitch(false);
            music.Pause();
        }
        else
        {
            musicentry = 1;
            _toggle.isOn = true;
            OnSwitch(true);
            music.Play();
        }
    }
    public void Save()
    {
        if(_toggle.isOn)
        {
            musicentry = 1;
            PlayerPrefs.SetInt("musicentry",1);
        }
        else
        {
            musicentry = 0;
            PlayerPrefs.SetInt("musicentry",0);
        }
    }
}
