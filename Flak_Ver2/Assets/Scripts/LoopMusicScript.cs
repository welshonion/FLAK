using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoopMusicScript : MonoBehaviour {

    //ForGameState***ReadOnly***
    GameObject gameController;
    GameControllerScript gameControllerScript;
    public State state;

    AudioSource LoopSource;

    double BGMDelay;
    public double DecideDelayTime;
    bool NowPlay;

    public bool HumanStateLMS;

    // Use this for initialization
    void Start () {

        LoopSource = GetComponent<AudioSource>();
        LoopPause();

        HumanStateLMS = false;

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
	void Update () {

        if (gameController != null)
        {
            state = gameControllerScript.state;
        }
        BGMDelay += Time.deltaTime;

        if (BGMDelay>= DecideDelayTime && NowPlay == false)
        { 
            LoopUnpause();

            HumanStateLMS = true;

            NowPlay = true;
        }


        if (state == State.Play)
        {
            LoopUnpause();
        }


        if (state != State.Play)
        {
            LoopPause();

            HumanStateLMS = false;
        }
    }

    void LoopUnpause()
    {
        LoopSource.UnPause();
    }

    void LoopPause()
    {
        LoopSource.Pause();
        NowPlay = false;
    }
}
