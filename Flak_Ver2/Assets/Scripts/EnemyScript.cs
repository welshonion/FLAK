using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public float enemy_speed = 1.0f;

    bool jud_gameover;

    GameObject gameController;

    public GameObject particle_base;
    GameObject particle;

    float step;

    float drop_angle = 0.0f;
    bool drop_jud = false;

    public AudioClip explosionSound;
    public AudioSource audioSource;


    // Update is called once per frame


    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Bullet" && drop_jud == false)
        {
            audioSource.PlayOneShot(explosionSound);
            particle = Instantiate(particle_base, transform.position, transform.rotation);
            drop_jud = true;
        }

        if (col.gameObject.tag == "Player")
        {
            //Debug.Log("over");
            gameController.SendMessage("Jud_GameOver");

        }

        if(col.gameObject.name == "WaterProDaytime")
        {
            Destroy(particle.gameObject);
            Destroy(this.gameObject);
        }
    }

    

    // Use this for initialization
    void Start()
    {
        drop_jud = false;
        drop_angle = 0.0f;
        gameController = GameObject.FindWithTag("GameController");

    }

    // Update is called once per frame
    void Update()
    {

        step = enemy_speed * Time.deltaTime;
        if(drop_jud == true)
        {
            drop_angle= drop_angle + Time.deltaTime * 20;
        }


        transform.position = Vector3.MoveTowards(transform.position, new Vector3(0, 40 - drop_angle * 50, 0), step);
        transform.LookAt(new Vector3(0,40 - drop_angle * 5 ,0));
        
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
}
