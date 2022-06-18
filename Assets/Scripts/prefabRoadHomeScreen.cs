using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class prefabRoadHomeScreen : MonoBehaviour
{   
    public float speed;
    Vector3 rota;
    void Start()
    {        Destroy(gameObject, 135);

        rota = new Vector3(0, 0, -1);
    }
    void Update()
    {
        transform.position += rota * speed * Time.deltaTime;
    }
}
