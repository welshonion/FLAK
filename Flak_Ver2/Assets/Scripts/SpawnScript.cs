﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnScript : MonoBehaviour
{

    //[SerializeField]
    float apperNextTime = 10.0f;
    float increasetime = 0.015f;
    /*[SerializeField]
    int maxNumOfEnemys = 10;*/

    public int numberOfEnemys;
    private float elapsedTime = 0.0f;

    public int spawn_distance = 30;
    private double spawn_x, spawn_z;
    private int spawn_angle;

    public float spawn_height = 100.0f;

    public float enemy_speed = 1.0f;
    float increase_speed = 0.0f;

    System.Random spawn_rnd = new System.Random();

    // Start is called before the first frame update
    void Start()
    {
        numberOfEnemys = 0;
        elapsedTime = 0f;
        SpawnEnemy();
        if (GetComponent<DifficultLevelScript>().showdiffi() == 0)
        {
            apperNextTime = 10.0f;
            increasetime = 0.04f;
            enemy_speed = 25.0f;
            increase_speed = 0.2f;
        }
        else
        {
            apperNextTime = 5.0f;
            increasetime = 0.06f;
            enemy_speed = 40.0f;
            increase_speed = 0.6f;
        }

    }

    // Update is called once per frame
    void Update()
    {
        apperNextTime -= Time.deltaTime * increasetime;
        enemy_speed += Time.deltaTime * increase_speed;

        /*if(numberOfEnemys >= maxNumOfEnemys)
        {
            return;
        }*/
        elapsedTime += Time.deltaTime;

        if(elapsedTime > apperNextTime && numberOfEnemys < 15)
        {
            SpawnEnemy();
            //Debug.Log(apperNextTime);
        }
        

    }

    public void SpawnEnemy()
    {
        //Debug.Log("Spawn");
        //spawn_angle = spawn_rnd.Next(360);
        spawn_angle = UnityEngine.Random.Range(-180, 20);
        //-180 -110
        //-70 0
        //0 70
        //120 180

        if (spawn_angle >= -100)
        {
            spawn_angle += 40;
        }
        if (spawn_angle >= 80)
        {
            spawn_angle += 50;
        }

        spawn_x = spawn_distance * Math.Cos(spawn_angle * (Math.PI / 180));
        spawn_z = spawn_distance * Math.Sin(spawn_angle * (Math.PI / 180));

        GameObject spawn_object = Resources.Load("Enemy") as GameObject;
        GameObject spawn_instance = Instantiate(spawn_object, new Vector3((float)spawn_x, spawn_height,(float)spawn_z), Quaternion.identity, this.transform);
        numberOfEnemys++;
        elapsedTime = 0f;
    }

    public void minus()
    {
        numberOfEnemys--;
    }
}