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
    public Transform muzzle_L, muzzle_R;
    [SerializeField]
    private float rotate_speed = 15.0f;

    private float gun_angle = 0.0f;

    private float firing_angle_x, firing_angle_y;

    System.Random firing_rnd = new System.Random();

    public AudioClip machineSound;
    AudioSource[] audioSource;
    int soundNum = 0;

    float pos_x, pos_y, pos_z;


    float shottime = 0.0f;

    bool jud_muzzle_is_l=true;

    public GameObject particle_flash;
    GameObject muzzleflash;

    bool jud_GunFireButton;
    bool jud_GunUpButton;
    bool jud_GunDownButton;

    // Start is called before the first frame update
    void Start()
    {
        ObjectGFS = GameObject.Find("GameController");
        if (ObjectGFS != null)
        {
            ControllerGFS = ObjectGFS.GetComponent<GameControllerScript>();
            audioSource = GetComponents<AudioSource>();
        }
        else
        {
            StateGFS = false;
        }

        jud_GunFireButton = false;
        jud_GunUpButton = false;
        jud_GunDownButton = false;
    }

    // Update is called once per frame
    void Update()
    {
        shottime += Time.deltaTime;

        if (ObjectGFS != null)
        {
            StateGFS = ControllerGFS.StateGCS;
        }
        gun_angle = transform.localEulerAngles.x;
        if (gun_angle > 180) gun_angle -= 360.0f;

        if ((Input.GetKey(KeyCode.W)||jud_GunUpButton) && gun_angle > -40 && StateGFS)
        {
            transform.Rotate(-1 * rotate_speed * Time.deltaTime, 0, 0);
        }
        if ((Input.GetKey(KeyCode.S)||jud_GunDownButton) && gun_angle < 10 && StateGFS)
        {
            transform.Rotate(1 * rotate_speed * Time.deltaTime, 0, 0);
        }

        if ((Input.GetKey(KeyCode.J) || jud_GunFireButton )&& StateGFS && shottime > 0.15f)
        {
            Shot();
            shottime = 0.0f;
        }
    }

    void Shot()
    {

        //audioSource.Stop();
        audioSource[soundNum].PlayOneShot(machineSound);
        soundNum = (soundNum + 1) % 4;
        audioSource[soundNum].Stop();

        firing_angle_x = (((float)(firing_rnd.Next(100)) / 50.0f) - 1.0f) * 1.5f;
        firing_angle_y = (((float)(firing_rnd.Next(100)) / 50.0f) - 1.0f) * 1.5f;
        //Debug.Log("shot");
        GameObject bullet_object = Resources.Load("Bullet") as GameObject;
        GameObject bullet_instance;
        if (jud_muzzle_is_l)
        {
            bullet_instance = Instantiate(bullet_object, muzzle_L.position, muzzle_L.rotation);
            muzzleflash = Instantiate(particle_flash, muzzle_L.position, muzzle_L.rotation);
            jud_muzzle_is_l = false;
        }
        else
        {
            bullet_instance = Instantiate(bullet_object, muzzle_R.position, muzzle_R.rotation);
            muzzleflash = Instantiate(particle_flash, muzzle_R.position, muzzle_R.rotation);
            jud_muzzle_is_l = true;
        }
        bullet_instance.transform.Rotate(firing_angle_x, firing_angle_y, 0);
        bullet_instance.GetComponent<Rigidbody>().AddForce(bullet_instance.transform.forward * bullet_power);

        float angle_x = transform.rotation.eulerAngles.x;
        float angle_y = transform.rotation.eulerAngles.y;
        float angle_z = transform.rotation.eulerAngles.z;

        pos_x = Mathf.Cos(angle_x * (float)Math.PI / 180) * Mathf.Sin(angle_y * (float)Math.PI / 180);
        pos_z = Mathf.Cos(angle_x + (float)Math.PI / 180) * Mathf.Cos(angle_y * (float)Math.PI / 180);
        pos_y = Mathf.Sin(angle_x * (float)Math.PI / 180);

        this.gameObject.transform.position = new Vector3(transform.position.x - 0.05f * pos_x, transform.position.y + 0.05f * pos_y, transform.position.z - 0.05f * pos_z);

        Invoke("recoil", 0.05f);
        Destroy(muzzleflash, 0.5f);
        Destroy(bullet_instance, 4f);
    }

    void recoil()
    {
        this.gameObject.transform.position = new Vector3(transform.position.x + 0.05f * pos_x, transform.position.y - 0.05f * pos_y, transform.position.z + 0.05f * pos_z);

    }

    public void GFPointUp()
    {
        jud_GunFireButton = false;
    }

    public void GFPointDown()
    {
        jud_GunFireButton = true;
    }

    public void GUPointUp()
    {
        jud_GunUpButton = false;
    }

    public void GUPointDown()
    {
        jud_GunUpButton = true;
    }

    public void GDPointUp()
    {
        jud_GunDownButton = false;
    }

    public void GDPointDown()
    {
        jud_GunDownButton = true;
    }
}
