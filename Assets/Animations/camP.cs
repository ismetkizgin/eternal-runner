using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camP : MonoBehaviour
{
    [SerializeField] GameObject player,aj,emy;
    public float cameraHeight = 6.0f;
    public float cameraDist = -7.0f;
   // private buttonFunction buttonFn=new buttonFunction();
    private void Start()
    {
       
        Debug.Log("PlayerPrefs.GetInt(character):"+ PlayerPrefs.GetInt("character"));
        if (PlayerPrefs.GetInt("character")== 0)//emy
        {   
            print("emy þecili");
            player = emy;
            aj.SetActive(false);
            emy.SetActive(true);
          
            
        }
        else if (PlayerPrefs.GetInt("character") == 1)//aj
        {
            player = aj;
            print("aj secili");
            aj.SetActive(true);
            emy.SetActive(false);
            // player = aj;
            // GameObject.Find("emy").GetComponent<GameObject>().SetActive(false);

        }
    }
    void LateUpdate()
    {
        Vector3 pos = player.transform.position;
        pos.y += cameraHeight;
        pos.z += cameraDist;
        transform.position = pos;
    }

}
