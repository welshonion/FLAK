using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    //ForGameState***ReadOnly***
    GameObject gameController;
    GameControllerScript gameControllerScript;
    public State state;

    public float enemy_speed = 1.0f;

    bool jud_gameover;

    public GameObject particle_base;
    GameObject particle;

    float step;

    float drop_angle = 0.0f;
    bool drop_jud = false;

    public AudioClip explosionSound;
    public AudioSource audioSource;

    public float enemy_height = 31.126f;

    GameObject SpawnObject;
    SpawnScript spawnscript;
    

    // Update is called once per frame


    void OnCollisionEnter(Collision col)
    {
        

        if (col.gameObject.tag == "Bullet" && drop_jud == false)
        {
            spawnscript.minus();
            audioSource.PlayOneShot(explosionSound);
            particle = Instantiate(particle_base, transform.position, transform.rotation);
            drop_jud = true;
            gameController.SendMessage("IncreaseScore");
        }

        if (col.gameObject.tag == "Player")
        {
            //GameObject bomb_object = Resources.Load("Bomb") as GameObject;
            //GameObject bomb_instance = Instantiate(bomb_object, new Vector3(this.transform.position.x, enemy_height-10.0f, this.transform.position.z), Quaternion.identity, this.transform);
            gameControllerScript.active_deathCamera();
            audioSource.PlayOneShot(explosionSound);
            particle = Instantiate(particle_base, new Vector3(0,35.0f,0), transform.rotation);
            //Debug.Log("over");
            Invoke("Send_GameOver", 0.5f);
            
            //Destroy(this.gameObject);

        }

        if(col.gameObject.name == "WaterProDaytime")
        {
            //Destroy(particle.gameObject);
            Destroy(this.gameObject);
        }
    }

    

    // Use this for initialization
    void Start()
    {
        drop_jud = false;
        drop_angle = 0.0f;

        gameController = GameObject.FindWithTag("GameController");
        if (gameController != null)
        {
            gameControllerScript = gameController.GetComponent<GameControllerScript>();
        }
        else
        {
            state = State.Ready;
        }

        SpawnObject = GameObject.FindGameObjectWithTag("SpawnerTag");

        spawnscript = SpawnObject.GetComponent<SpawnScript>();

        enemy_speed = spawnscript.enemy_speed;

    }

    // Update is called once per frame
    void Update()
    {

        if (gameController != null)
        {
            state = gameControllerScript.state;
        }

        if (state == State.Play)
        {
            step = enemy_speed * Time.deltaTime;
            if (drop_jud == true)
            {
                drop_angle = drop_angle + Time.deltaTime * 20;
            }


            transform.position = Vector3.MoveTowards(transform.position, new Vector3(0, enemy_height - drop_angle * 50, 0), step);
            transform.LookAt(new Vector3(0, enemy_height - drop_angle * 3, 0));
        }
   
    }

    /*void ApplyAngle()
    {

        float targetAngle;


        if (isDead)
        {
            targetAngle = -90.0f;
        }
        else
        {
            targetAngle = Mathf.Atan2(rb2d.velocity.y, relativeVelocityX) * Mathf.Rad2Deg;
        }

        angle = Mathf.Lerp(angle, targetAngle, Time.deltaTime * 10.0f);

        sprite.transform.localRotation = Quaternion.Euler(0.0f, 0.0f, angle);

    }*/

    public void Send_GameOver()
    {
        gameController.SendMessage("Jud_GameOver");
    }
}
