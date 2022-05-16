using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Touch;

public class MoveByTouch : MonoBehaviour
{

    void Update()
    {
        for(int i= 0; i<Input.touchCount; i++)
        {
            //MoveByTouch touch = Input.GetTouch(0);
            Vector3 touchPosition = Camera.main.ScreenToWorldPoint(Input.touches[i].position);
            Debug.DrawLine(Vector3.zero, touchPosition, Color.red);
        }
    }
}
