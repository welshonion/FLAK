using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointerScript : MonoBehaviour
{
    public GameObject gunBase;
    private float tekubi;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        tekubi = gunBase.transform.localEulerAngles.y;
        transform.localRotation = Quaternion.Euler(0, 0, -1*tekubi);
    }
}
