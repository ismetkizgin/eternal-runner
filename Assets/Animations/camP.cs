using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camP : MonoBehaviour
{
    public GameObject player;
    public float cameraHeight = 6.0f;
    public float cameraDist = -7.0f;

    void LateUpdate()
    {
        Vector3 pos = player.transform.position;
        pos.y += cameraHeight;
        pos.z += cameraDist;
        transform.position = pos;
    }

}
