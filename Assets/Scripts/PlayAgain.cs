using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayAgain : MonoBehaviour
{
    public void playScene(int scene_id)
    {
        SceneManager.LoadScene(1);
    }
    public void mainScene(int scene_id)
    {
        SceneManager.LoadScene(0);
    }
    public void doExitGame()
    {
        Application.Quit();
    }

}
