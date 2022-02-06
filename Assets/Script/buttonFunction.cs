using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class buttonFunction : MonoBehaviour
{
    /*
    Burdaki kodlar HomeScreen ve SettingScreen de kullanılmakta.
    */
    public GameObject settingscreen;
    public GameObject mainscreen;
    //public GameObject characterselectionscreen;

    public void Play()
    {
        SceneManager.LoadScene("SahneGame");//Oyun Sahnesine Geçiş
    }

    public void Settings()
    {
        mainscreen.SetActive(false);
        settingscreen.SetActive(true);
    }

    public void CharacterSelection()
    {
        //mainscreen.SetActive(false);
        //characterselectionscreen.SetActive(true);
    }

    public void HomeScreen()
    {
        settingscreen.SetActive(false);
        //characterselectionscreen.SetActive(false);
        mainscreen.SetActive(true);
    }
}
