using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PropellerScript : MonoBehaviour
{
    //ForGameState***ReadOnly***
    GameObject gameController;
    GameControllerScript gameControllerScript;
    public State state;

    // Start is called before the first frame update
    void Start()
    {

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
            transform.Rotate(new Vector3(0, 0, -20));
        }

    }
}
