using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunBaseScript : MonoBehaviour
{
    public GameControllerScript ControllerGBS;
    public GameObject ObjectGBS;
    bool StateGBS;

    [SerializeField]
    private float rotate_speed = 15.0f;

    private float gun_angle=0.0f;




    // Start is called before the first frame update
    void Start()
    {
        ObjectGBS = GameObject.Find("GameController");
        if (ObjectGBS != null)
        {
            ControllerGBS = ObjectGBS.GetComponent<GameControllerScript>();
        }
        else
        {
            StateGBS = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(ObjectGBS != null)
        {
            StateGBS = ControllerGBS.StateGCS;
        }

        gun_angle = transform.localEulerAngles.x;
        if (gun_angle > 180) gun_angle -= 360.0f;

        if (Input.GetKey(KeyCode.D) && StateGBS)
        {
            transform.Rotate(0, rotate_speed * Time.deltaTime, 0);
        }
        if (Input.GetKey(KeyCode.A) && StateGBS)
        {
            transform.Rotate(0, -1 * rotate_speed * Time.deltaTime, 0);
        }

    }

}
