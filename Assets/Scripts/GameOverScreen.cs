using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{
    public Text pointsText;

    public void Setup(int score)
    {
        gameObject.SetActive(true);
        pointsText.text = score.ToString() + "POINTS";

    }
    public void PlayAgainButton()
    {
        SceneManager.LoadScene("SampleScene"); // oyun sahnesý 

    }
    public void ExitButton()
    {
        SceneManager.LoadScene("HomeScreen");
    }
    public void QuitGame()
    {

        Application.Quit();
    }


}



