using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunBaseScript : MonoBehaviour
{
    //ForGameState***ReadOnly***
    GameObject gameController;
    GameControllerScript gameControllerScript;
    public State state;

    [SerializeField]
    private float rotate_speed = 15.0f;

    private float gun_angle=0.0f;

    AudioSource motorSound;
    bool jud_playing=false;

    bool jud_GunRightButton;
    bool jud_GunLeftButton;




    // Start is called before the first frame update
    void Start()
    {
        gameController = GameObject.FindWithTag("GameController");
        if (gameController != null)
        {
            gameControllerScript = gameController.GetComponent<GameControllerScript>();
            motorSound = GetComponent<AudioSource>();
        }
        else
        {
            state = State.Ready;
        }

        motorSound = GetComponent<AudioSource>();

        jud_GunRightButton = false;
        jud_GunLeftButton = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(gameController != null)
        {
            state = gameControllerScript.state;
        }

        gun_angle = transform.localEulerAngles.x;
        if (gun_angle > 180) gun_angle -= 360.0f;

        if ((Input.GetKey(KeyCode.D) || jud_GunRightButton) && state == State.Play)
        {
            transform.Rotate(0, rotate_speed * Time.deltaTime, 0);
        }
        if ((Input.GetKey(KeyCode.A) || jud_GunLeftButton) && state == State.Play)
        {
            transform.Rotate(0, -1 * rotate_speed * Time.deltaTime, 0);
        }
        

        if ((Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D)) && state == State.Play && !jud_playing)
        {
            motorSound.loop = true;
            motorSound.Play();
            jud_playing = true;

        }


        if ((Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.D)) && state == State.Play && !(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D)))
        {
            motorSound.loop = false;
            jud_playing = false;
        }

    }

    public void GRPointUp()
    {
        jud_GunRightButton = false;
    }

    public void GRPointDown()
    {
        jud_GunRightButton = true;
    }

    public void GLPointUp()
    {
        jud_GunLeftButton = false;
    }

    public void GLPointDown()
    {
        jud_GunLeftButton = true;
    }

}
