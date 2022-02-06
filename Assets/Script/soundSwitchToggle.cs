using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class soundSwitchToggle : MonoBehaviour
{
    [SerializeField] RectTransform uihandlerecttransform;//[SerializeField] ile Public aynı mantık
    [SerializeField] Color backgroundactivecolor;
    [SerializeField] Color handleactivecolor;
    Image _backgroundImage, _handleImage;
    Color _backgroundDefaultColor, _handleDefaultColor;
    Toggle _toggle;
    Vector2 _handlePosition;
    public int soundentry;
    public GameObject soundswitchtoggle;


    void Awake()
    {
        _toggle = soundswitchtoggle.GetComponent <Toggle> ();
        _handlePosition = uihandlerecttransform.anchoredPosition; //canvastaki anchored pozisyonuna erişiyor

        _backgroundImage = uihandlerecttransform.parent.GetComponent <Image>();
        _handleImage = uihandlerecttransform.GetComponent <Image> ();

        _backgroundDefaultColor = _backgroundImage.color;
        _handleDefaultColor = _handleImage.color;

        if(!PlayerPrefs.HasKey("soundentry"))
        {
            PlayerPrefs.SetInt("soundentry",1);
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

    public void ChangeSound()
    {
        //AudioListener.pause = toggle.isOn;
        Save();
        if(_toggle.isOn)
        {
            OnSwitch(true);
        }
        else
        {
            OnSwitch(false);
        }
    }
    public void Load()
    {
        if(PlayerPrefs.GetInt("soundentry") == 0)
        {
            soundentry = 0;
            _toggle.isOn = false;
            OnSwitch(false);
        }
        else
        {
            soundentry = 1;
            _toggle.isOn = true;
            OnSwitch(true);
        }
    }
    public void Save()
    {
        if(_toggle.isOn)
        {
            soundentry = 1;
            PlayerPrefs.SetInt("soundentry",1);
        }
        else
        {
            soundentry = 0;
            PlayerPrefs.SetInt("soundentry",0);
        }
    }
}
