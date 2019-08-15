using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public GameObject objectCS;
    public GameControllerScript controllerCS;
    bool stateCS;

    [SerializeField]
    private float rotate_speed = 15.0f;

    private float camera_angle = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        objectCS = GameObject.Find("GameController");
        if (objectCS != null)
        {
            controllerCS = objectCS.GetComponent<GameControllerScript>();
        }
        else
        {
            stateCS = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (objectCS != null)
        {
            stateCS = controllerCS.StateGCS;
        }

        if (stateCS)
        {
            camera_angle = transform.localEulerAngles.x;
            if (camera_angle > 180) camera_angle -= 360.0f;

            if (Input.GetKey(KeyCode.W) && camera_angle > -40)
            {
                transform.Rotate(-1 * rotate_speed * Time.deltaTime, 0, 0);
                transform.position += new Vector3(0, -0.2f * Time.deltaTime, 0);
            }
            if (Input.GetKey(KeyCode.S) && camera_angle < 10)
            {
                transform.Rotate(1 * rotate_speed * Time.deltaTime, 0, 0);
                transform.position += new Vector3(0, 0.2f * Time.deltaTime, 0);
            }
        }
 
    }
}
