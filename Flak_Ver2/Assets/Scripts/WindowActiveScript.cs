using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowActiveScript: MonoBehaviour {

    // Use this for initialization
    void Start () {
        gameObject.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {

    }
    
    public void Active()
    {
        gameObject.SetActive(true);
    }

    public void Hidden()
    {
        gameObject.SetActive(false);
    }
}
