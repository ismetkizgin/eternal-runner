using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclesController : MonoBehaviour
{
    float timer=0;
    [SerializeField]GameObject character;
    [SerializeField] List<Mesh> obstacles = new List<Mesh>();
    [SerializeField] Material material;
    [SerializeField] float howManySecObstacles = 1.5f, howManyMetersObstacles = 250;
    private void Start()
    {   
        //oyun başladığında önümüze bir miktar engel oluşturuyor.
        for (int i = 15; i <= 250; i += 15)
        {
            createObstacles(0, i);
        }
    }
    void Update()
    {   
        //oyun başlayınca hep bir miktar ilerimize engel oluşturuyor.
        createObstacles(howManySecObstacles,howManyMetersObstacles);
    }
    void createObstacles(float howManySecObstacles,float howManyMetersObstacles)
    {   
        timer += Time.deltaTime;
        //howmanySecObstacles:kaç saniyede bir engel çıkmasını söyler
        if (timer > howManySecObstacles)
        {
            GameObject gameObj = new GameObject("engel");
            gameObj.gameObject.tag = "Obstacle";
            float randomsX = Random.Range(42, 56);

            //yeni oluşan objeye meshFilter verip içine engellerimizden birinin Meshini veriyoruz
            MeshFilter gameObjMeshFilter = gameObj.AddComponent<MeshFilter>();
            int whichObstacle = Random.Range(0, 4);
            gameObjMeshFilter.sharedMesh = obstacles[whichObstacle];

            //yeni olusan objeye meshRenderer veriyoruz.engelimizin materiyalini belirliyoruz.
            MeshRenderer gameObjMeshRenderer = gameObj.AddComponent<MeshRenderer>();
            gameObjMeshRenderer.material = material;

            //yeni oluşan objeye boxcollider verip istrighger ayari yapiyoruz
            BoxCollider gameObjCollider = gameObj.AddComponent<BoxCollider>();
            gameObjCollider.isTrigger = true;

            //Objeler tutarlı olmadığı için rotasyon,positionuyla oynamamamız gerekmektedir.
            if (whichObstacle == 0)//roadA
            {
                gameObj.transform.position = new Vector3(randomsX, character.transform.position.y, character.transform.position.z + howManyMetersObstacles);
                gameObj.transform.rotation = Quaternion.Euler(-90, 0, 90);
                gameObj.transform.localScale = new Vector3(2, 2, 2);
            }
            else if (whichObstacle == 1)//fuse
            {
                gameObj.transform.position = new Vector3(randomsX, character.transform.position.y + 1.4f, character.transform.position.z + howManyMetersObstacles);
                gameObj.transform.rotation = Quaternion.Euler(0, 90, 0);
                gameObj.transform.localScale = new Vector3(2.5f, 2.5f, 2.5f);
            }
            else if (whichObstacle == 2)//roadD
            {
                gameObj.transform.position = new Vector3(randomsX, character.transform.position.y, character.transform.position.z + howManyMetersObstacles);
                gameObj.transform.rotation = Quaternion.Euler(-90, 0, 90);
                gameObj.transform.localScale = new Vector3(2, 2, 2);
            }
            else if (whichObstacle == 3)//newsboard
            {
                gameObj.transform.position = new Vector3(randomsX, character.transform.position.y + 1.4f, character.transform.position.z + howManyMetersObstacles);
                gameObj.transform.rotation = Quaternion.Euler(0, 90, 0);
                gameObj.transform.localScale = new Vector3(2, 2, 2);
            }

            //belli bir miktar süre sonra objeler yok oluyor.
            Destroy(gameObj,40);

            timer = 0;
        }
    }

}
