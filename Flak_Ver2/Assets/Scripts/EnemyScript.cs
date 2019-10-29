using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public GameControllerScript ControllerES;
    public GameObject ObjectES;
    bool StateES;

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
            ObjectES.SendMessage("Jud_GameOver");
            Destroy(this.gameObject);

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

        ObjectES = GameObject.Find("GameController");
        if (ObjectES != null)
        {
            ControllerES = ObjectES.GetComponent<GameControllerScript>();
        }
        else
        {
            StateES = false;
        }

    }

    // Update is called once per frame
    void Update()
    {

        if (ObjectES != null)
        {
            StateES = ControllerES.StateGCS;
        }

        if (StateES)
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
}
