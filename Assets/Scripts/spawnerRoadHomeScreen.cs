using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnerRoadHomeScreen : MonoBehaviour
{
    public GameObject roads;
    public GameObject firstroad;
    void Start()
    {
        StartCoroutine(SpawnObject());
        firstroad.transform.position = new Vector3(113, -166, 363);
    }
    IEnumerator SpawnObject()
    {
        while(true)
        {
            yield return new WaitForSeconds(19);
            Instantiate(roads, new Vector3(113, -166, 940), Quaternion.Euler(-90, 0, 0));
            yield return new WaitForSeconds(59);
        }
    }
}
