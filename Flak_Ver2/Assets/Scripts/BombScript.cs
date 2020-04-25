using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombScript : MonoBehaviour
{
    GameObject gameController;
    GameControllerScript gameControllerScript;

    public GameObject particle_base;
    GameObject particle;

    public AudioClip explosionSound;
    public AudioSource audioSource;

    float step;

    /*void OnCollisionEnter(Collision col)
    {


        if (col.gameObject.tag != "EnemyTag"&& col.gameObject.tag != "Player")
        {
            audioSource.PlayOneShot(explosionSound);
            particle = Instantiate(particle_base, transform.position, transform.rotation);
            
           
            gameController.SendMessage("Jud_GameOver");
            //Destroy(this.gameObject);

        }

    }*/

    // Start is called before the first frame update
    void Start()
    {
        gameController = GameObject.Find("GameController");
        if (gameController != null)
        {
            gameControllerScript = gameController.GetComponent<GameControllerScript>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        step = 30.0f * Time.deltaTime;


        transform.position = Vector3.MoveTowards(transform.position, new Vector3(0, 0, 0), step);
        transform.LookAt(new Vector3(0, 0, 0));

        if (this.transform.position.y < 10.0f)
        {
            audioSource.PlayOneShot(explosionSound);
            particle = Instantiate(particle_base, transform.position, transform.rotation);


            gameController.SendMessage("Jud_GameOver");
            Invoke("Destroy(this.gameObject)",1.0f);
        }
    }
}
