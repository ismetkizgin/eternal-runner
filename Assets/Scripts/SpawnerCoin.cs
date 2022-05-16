using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Random;
using Random = System.Random;

public class SpawnerCoin : MonoBehaviour
{
    public List<Transform> spawnPoints = new List<Transform>();
    [SerializeField] private GameObject coin;


    void Start()
    {
        var r = new Random();
        int a = (int)Math.Ceiling(spawnPoints.Count / 2.0f);

        HashSet<int> randomValues = new HashSet<int>();
        while (randomValues.Count < a)
        {
            randomValues.Add(item: r.Next(0, spawnPoints.Count-1 ));
        }
        foreach (var x in randomValues)
        {
            Instantiate(coin, spawnPoints[x]);
        }
    }


 
    
}
