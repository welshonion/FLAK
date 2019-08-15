using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public GameObject spawnObject;
    SpawnScript SpawnScript_BS;


    GameObject gameController;


    // Start is called before the first frame update
    void Start()
    {
        gameController = GameObject.FindWithTag("GameController");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "EnemyTag")
        {
            gameController.SendMessage("IncreaseScore");
            /*spawnObject = GameObject.Find("Spawner");
            SpawnScript_BS = spawnObject.GetComponent<SpawnScript>();
            SpawnScript_BS.numberOfEnemys--;*/
            Destroy(col.gameObject);

        }
        Destroy(gameObject);
    }

}
