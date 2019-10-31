using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombScript : MonoBehaviour
{
    public GameControllerScript ControllerES;
    public GameObject ObjectES;

    public GameObject particle_base;
    GameObject particle;

    public AudioClip explosionSound;
    public AudioSource audioSource;

    void OnCollisionEnter(Collision col)
    {


        if (col.gameObject.tag != "EnemyTag"&& col.gameObject.tag != "Player")
        {
            audioSource.PlayOneShot(explosionSound);
            particle = Instantiate(particle_base, transform.position, transform.rotation);
            
           
            ObjectES.SendMessage("Jud_GameOver");
            //Destroy(this.gameObject);

        }

    }

    // Start is called before the first frame update
    void Start()
    {
        ObjectES = GameObject.Find("GameController");
        if (ObjectES != null)
        {
            ControllerES = ObjectES.GetComponent<GameControllerScript>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
