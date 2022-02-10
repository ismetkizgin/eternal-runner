using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera : MonoBehaviour
{
    public GameObject top;
    public Vector3 aradakiFark;
    // Start is called before the first frame update
    void Start()
    {
        aradakiFark = transform.position - top.transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = top.transform.position + aradakiFark;
    }
}
