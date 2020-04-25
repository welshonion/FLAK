using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DifficultLevelScript : MonoBehaviour
{
    public static int difficultnum = 0; 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void set0()
    {
        difficultnum = 0;
    }
    public void set1()
    {
        difficultnum = 1;
    }
    public int showdiffi()
    {
        return difficultnum;
    }
}
