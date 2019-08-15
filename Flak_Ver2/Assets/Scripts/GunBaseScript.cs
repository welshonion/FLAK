using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunBaseScript : MonoBehaviour
{

    [SerializeField]
    private float rotate_speed = 15.0f;

    private float gun_angle=0.0f;




    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gun_angle = transform.localEulerAngles.x;
        if (gun_angle > 180) gun_angle -= 360.0f;

        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(0, rotate_speed * Time.deltaTime, 0);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(0, -1 * rotate_speed * Time.deltaTime, 0);
        }

    }

}
