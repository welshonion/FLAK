using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonColorScript : MonoBehaviour
{
    public Button wkey;
    public Button akey;
    public Button skey;
    public Button dkey;
    public Button spkey;
    public Button jkey;


    Color colors_red = new Color(1, 1, 1);
    Color colors_white = new Color(0, 0, 0);


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            wkey.Select();
        }
        if (Input.GetKey(KeyCode.A))
        {
            akey.Select();
        }
        if (Input.GetKey(KeyCode.S))
        {
            skey.Select();
        }
        if (Input.GetKey(KeyCode.D))
        {
            dkey.Select();
        }
        if (Input.GetKey(KeyCode.W))
        {
            wkey.Select();
        }
        
        if (Input.GetKey(KeyCode.J))
        {
            jkey.Select();
        }
        if (Input.GetKey(KeyCode.Space))
        {
            spkey.Select();
        }


    }
}
