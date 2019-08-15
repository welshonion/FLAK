using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopScreen : MonoBehaviour {

    // Use this for initialization
    void Start () {
        gameObject.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {

    }
    
    public void Pause()
    {
        gameObject.SetActive(true);
    }

    public void BackPause()
    {
        gameObject.SetActive(false);
    }
}
