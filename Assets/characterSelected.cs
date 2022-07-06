using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterSelected : MonoBehaviour
{
    public List<GameObject> gameObjects;

    void Start()
    {


        foreach (GameObject item in gameObjects)
        {
            if (item == gameObjects[PlayerPrefs.GetInt("character")])
            {
                continue;
            }
            item.SetActive(false);
        }

        //gameObjects[PlayerPrefs.GetInt("character")].SetActive(true);
    }

}
