using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public float right=53.6f;
    public float left=45.5f;
    public float middle=49.1f;
    public GameObject a, b , c,d;
    public Transform character;

    void Start()
    {
        InvokeRepeating("clone", 0,1.5f);
    }

    public void clone()
    {
        int number = Random.Range(0, 5);
       
        if (number==2)
        {
            create(a, 2.5f);
        }
        if (number ==1)
        {
            create(c, 2.5f);
        }
        if (number ==3)
        {
            create(b, 4.0f);
        }
        if (number ==4)
        {
            create(d, 4.0f);
        }
    }

    public void create(GameObject obstacle , float top)
    {
        GameObject newclone = Instantiate(obstacle);
        int number = Random.Range(0, 100);

        if (number < 30)
        {
            newclone.transform.position = new Vector3(right, top, character.position.z + 500.0f);
            
          
        }
        if(number>30 && number < 60)
        {
           newclone.transform.position = new Vector3(left, top, character.position.z + 500.0f);
        }

        if (number > 60 && number < 100)
        {
            newclone.transform.position = new Vector3(middle, top, character.position.z + 500.0f);
        }

        Destroy(newclone, 15.0f);
    }
 
}
