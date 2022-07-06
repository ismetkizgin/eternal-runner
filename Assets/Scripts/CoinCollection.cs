using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CoinCollection : MonoBehaviour
{
    private AudioSource click;
    public int scoreValue;
    private scoreManager sManager;

    private void Start()
    {
        click = GetComponent<AudioSource>();
        sManager = FindObjectOfType<scoreManager>();
    }


    private void OnTriggerEnter(Collider other)
    {
            if (other.gameObject.CompareTag("coin"))
            {
                sManager.AddScore(scoreValue);
                other.gameObject.SetActive(false);


                Destroy(other.gameObject);
                click.Play();
            }

            if (other.gameObject.CompareTag("Engel"))
            {
            
                SceneManager.LoadScene("endscreen");
            }
            
    }

}
