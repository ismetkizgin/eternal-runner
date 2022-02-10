using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class top : MonoBehaviour
{
    public Rigidbody fizik;
    public float hiz;
    // Start is called before the first frame update
    void Start()
    {
        fizik = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float yatay = Input.GetAxisRaw("Horizontal");
        float dikey = Input.GetAxisRaw("Vertical");

       // transform.Translate(yatay * hiz, 0, dikey * hiz);
        //     Debug.Log(transform.position);
        fizik.AddForce(yatay * hiz, 0, dikey * hiz);

            }
}
