using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunFrameScript : MonoBehaviour
{
    public GameControllerScript ControllerGFS;
    public GameObject ObjectGFS;
    bool StateGFS;

    [SerializeField]
    private float bullet_power = 100.0f;
    [SerializeField]
    private Transform muzzle;
    [SerializeField]
    private float rotate_speed = 15.0f;

    private float gun_angle = 0.0f;

    private float firing_angle_x, firing_angle_y;

    System.Random firing_rnd = new System.Random();


    // Start is called before the first frame update
    void Start()
    {
        ObjectGFS = GameObject.Find("GameController");
        if (ObjectGFS != null)
        {
            ControllerGFS = ObjectGFS.GetComponent<GameControllerScript>();
        }
        else
        {
            StateGFS = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (ObjectGFS != null)
        {
            StateGFS = ControllerGFS.StateGCS;
        }
        gun_angle = transform.localEulerAngles.x;
        if (gun_angle > 180) gun_angle -= 360.0f;

        if (Input.GetKey(KeyCode.W) && gun_angle > -40 && StateGFS)
        {
            transform.Rotate(-1 * rotate_speed * Time.deltaTime, 0, 0);
        }
        if (Input.GetKey(KeyCode.S) && gun_angle < 10 && StateGFS)
        {
            transform.Rotate(1 * rotate_speed * Time.deltaTime, 0, 0);
        }

        if (Input.GetKey(KeyCode.J) && StateGFS)
        {
            Shot();
        }
    }

    void Shot()
    {
        firing_angle_x = ((float)(firing_rnd.Next(100)) / 50.0f) - 5.0f;
        firing_angle_y = ((float)(firing_rnd.Next(100)) / 50.0f) - 5.0f;
        //Debug.Log("shot");
        GameObject bullet_object = Resources.Load("Bullet") as GameObject;
        GameObject bullet_instance = Instantiate(bullet_object, muzzle.position, muzzle.rotation);
        bullet_instance.transform.Rotate(firing_angle_x,firing_angle_y,0);
        bullet_instance.GetComponent<Rigidbody>().AddForce(bullet_instance.transform.forward * bullet_power);
        Destroy(bullet_instance, 3f);
    }
}
