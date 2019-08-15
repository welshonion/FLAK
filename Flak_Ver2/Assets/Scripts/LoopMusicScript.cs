using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoopMusicScript : MonoBehaviour {

    public GameControllerScript ControllerLMS;
    public GameObject ObjectLMS;
    bool StateLMS;

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

        ObjectLMS = GameObject.Find("GameController");
        if (ObjectLMS != null)
        {
            ControllerLMS = ObjectLMS.GetComponent<GameControllerScript>();
        }
        else
        {
            StateLMS = false;
        }

    }
	
	// Update is called once per frame
	void Update () {

        if (ObjectLMS != null)
        {
            StateLMS = ControllerLMS.StateGCS;
        }
        BGMDelay += Time.deltaTime;

        if (BGMDelay>= DecideDelayTime && NowPlay == false)
        { 
            LoopUnpause();

            HumanStateLMS = true;

            NowPlay = true;
        }


        if (StateLMS == false)
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
