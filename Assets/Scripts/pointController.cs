using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pointController : MonoBehaviour
{
    private AudioSource click;
    [SerializeField] int scoreValue;
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

            click.Play();
        }

        if (other.gameObject.CompareTag("Obstacle"))
        {
           
            SceneManager.LoadScene("endscreen");
        }
        
    }
}
