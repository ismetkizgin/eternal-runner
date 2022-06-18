using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CoinCollection : MonoBehaviour
{
     
    [SerializeField]private GameObject character;
    float timer = 0;
    [SerializeField] GameObject originalCoinPrefab;
    [SerializeField] float howManySecObstacles = .5f, howManyMetersObstacles = 250;
    private void Start()
    {
        for (float i = 0; i < howManyMetersObstacles; i+= ((howManySecObstacles)*15))
        {
            print("sae");
            createCoin(0,i);
        }
    }
    private void Update()
    {
        createCoin( howManySecObstacles, howManyMetersObstacles);
    }
    void createCoin(float howManySecObstacles, float howManyMetersObstacles )
    {
        timer += Time.deltaTime;
        if (timer>howManySecObstacles)
        {
            Debug.Log("girdi");
            
            GameObject CoinPrefab=Instantiate(originalCoinPrefab,new Vector3(Random.Range(40,58),character.transform.position.y+1.63f,character.transform.position.z+howManyMetersObstacles) ,character.transform.rotation);
            CoinPrefab.tag="coin";
            Destroy(CoinPrefab, 25 );
            timer = 0;
        }
      
    }

   

}

