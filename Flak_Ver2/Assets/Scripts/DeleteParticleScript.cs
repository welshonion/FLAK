﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteParticleScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("DeleteParticle", 2);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void DeleteParticle()
    {
        Destroy(this.gameObject);
    }
}
