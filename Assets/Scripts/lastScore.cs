using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class lastScore : MonoBehaviour
{
    //private scoreManager sManager;
    public Text scoreText;
    float score;

    // Start is called before the first frame update
    void Start()
    {
        Score();
    }

    // Update is called once per frame
    void Score()
    {
        score = scoreManager.instance.scoreCount;
        scoreText.text = "Score:" + Mathf.Round(score);

    }
    public void Pagain()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
