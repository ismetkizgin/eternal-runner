using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerDead : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider collision)
    {
        //karakter engele çarparsa ölüyor
        if (collision.gameObject.tag=="Obstacle")
        {
            SceneManager.LoadScene("endscreen");
        }
    }
}
