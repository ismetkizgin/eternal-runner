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
    // Start is called before the first frame update
    private void Awake()
    {
        instance = this;
        DontDestroyOnLoad(this.gameObject);
    }
    void Start()
    {

        
    }

    // Update is called once per frame
    void Update()
    {
        if(scoreInc)
        {
            scoreCount += scorePsecond * Time.deltaTime;
        }
        scoreText.text = "Score:" + Mathf.Round(scoreCount);
    }
    public void AddScore(int pointsToAdd)
    {
        scoreCount += pointsToAdd;
    }
}
