using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate: MonoBehaviour
{
    [SerializeField] private float speedX;
    [SerializeField] private float speedY;
    [SerializeField] private float speedZ;
    public GameObject[] para;
    public int set=0;
    public float changeCoin=0;

    void Start()
    {
 
    }

    void Update()
    {

        transform.Rotate(xAngle: 360 * speedX * Time.deltaTime, yAngle: 360 * speedY * Time.deltaTime, zAngle: 360 * speedZ * Time.deltaTime);
        
        if(set==0)
        {
            onOff();
            set++;
        }
        changeCoin += 1 * Time.deltaTime;
        if (changeCoin>=25)
        {
            set++;
            changeCoin = 0;
            onOff();

        }
    }

    private void onOff()
    {
            for(int i=0;i<=28;i++)
            {
            int rand = Random.Range(0, 10);
                if(rand<=5)
                {
                    para[i].SetActive(true);
                }
                if (rand > 5)
                {
                    para[i].SetActive(false);
                }

            }
     
    }
}
