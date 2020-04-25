using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class RadarController : MonoBehaviour
{
    //ForGameState***ReadOnly***
    GameObject gameController;
    GameControllerScript gameControllerScript;
    public State state;

    public Image rend;
    float angleinfo = 0;

    // Start is called before the first frame update
    void Start()
    {
        rend = GameObject.Find("RadarImage").GetComponent<Image>();

        gameController = GameObject.FindWithTag("GameController");
        if (gameController != null)
        {
            gameControllerScript = gameController.GetComponent<GameControllerScript>();
        }
        else
        {
            state = State.Ready;
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (gameController != null)
        {
            state = gameControllerScript.state;
        }

        if (state == State.Play)
        {
            transform.Rotate(new Vector3(0, 1, 0));
            angleinfo = (int)(transform.localEulerAngles.y /*+ 181*/) % 360;
            //Debug.Log(angleinfo);
            rend.material.SetFloat("_FValue", angleinfo);
        }

    }
}
