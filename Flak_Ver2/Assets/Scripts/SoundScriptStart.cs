using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundScriptStart : MonoBehaviour
{

    AudioSource DecideSource;

    public AudioClip Decide1;
    public AudioClip Decide2;
    public AudioClip Decide3;

    public bool DontDestroyEnabledStart = true;

    // Use this for initialization
    void Start()
    {

        if (DontDestroyEnabledStart)
        {
            DontDestroyOnLoad(this);
        }

        DecideSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void DecideSound1()
    {
        DecideSource.PlayOneShot(Decide1);
    }

    public void DecideSound2()
    {
        DecideSource.PlayOneShot(Decide2);
    }

    public void DecideSound3()
    {
        DecideSource.PlayOneShot(Decide3);
    }
}
