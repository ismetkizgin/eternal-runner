using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scoreManager : MonoBehaviour
{
    public static scoreManager instance;
    public Text scoreText;
    public int scorePsecond;
    public bool scoreInc;
    public float scoreCount;
    public AudioSource audio2;

    private void Awake()
    {
        instance = this;
        DontDestroyOnLoad(this.gameObject);
    }
    void Start()
    {
        audio2 = GetComponent<AudioSource>();
    }
    void Update()
    {
        if(scoreInc)
        {
            scoreCount += scorePsecond * Time.deltaTime;
        }
        scoreText.text = "Score:" + Mathf.Round(scoreCount);
       if (scoreCount>10)
        {
            audio2.Play();
        }
    }
    public void AddScore(int pointsToAdd)
    {
        scoreCount += pointsToAdd;
    }
}