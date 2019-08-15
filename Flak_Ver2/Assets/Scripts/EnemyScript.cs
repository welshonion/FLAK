using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public float enemy_speed = 1.0f;

    bool jud_gameover;

    GameObject gameController;


    // Update is called once per frame


    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Player")
        {
            Debug.Log("over");
            gameController.SendMessage("Jud_GameOver");

        }
    }

    // Use this for initialization
    void Start()
    {
        gameController = GameObject.FindWithTag("GameController");
    }

    // Update is called once per frame
    void Update()
    {

        float step = enemy_speed * Time.deltaTime;

        transform.position = Vector3.MoveTowards(transform.position, new Vector3(0, 40, 0), step);
        transform.LookAt(new Vector3(0,40,0));   
        
    }
}
