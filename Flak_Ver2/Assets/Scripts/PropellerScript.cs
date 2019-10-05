using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PropellerScript : MonoBehaviour
{
    public GameObject objectPS;
    public GameControllerScript controllerPS;
    bool statePS;

    // Start is called before the first frame update
    void Start()
    {

        objectPS = GameObject.Find("GameController");
        if (objectPS != null)
        {
            controllerPS = objectPS.GetComponent<GameControllerScript>();
        }
        else
        {
            statePS = true;
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (objectPS != null)
        {
            statePS = controllerPS.StateGCS;
        }

        if (statePS)
        {
            transform.Rotate(new Vector3(0, 0, -20));
        }

    }
}
