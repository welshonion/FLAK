using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnScript : MonoBehaviour
{

    [SerializeField]
    float apperNextTime = 3.0f;
    /*[SerializeField]
    int maxNumOfEnemys = 10;*/

    public int numberOfEnemys;
    private float elapsedTime = 0.0f;

    public int spawn_distance = 30;
    private double spawn_x, spawn_z;
    private int spawn_angle;

    public float spawn_height = 100.0f;

    System.Random spawn_rnd = new System.Random();

    // Start is called before the first frame update
    void Start()
    {
        numberOfEnemys = 0;
        elapsedTime = 0f;
        SpawnEnemy();

    }

    // Update is called once per frame
    void Update()
    {
        apperNextTime -= Time.deltaTime * 0.015f;

        /*if(numberOfEnemys >= maxNumOfEnemys)
        {
            return;
        }*/
        elapsedTime += Time.deltaTime;

        if(elapsedTime > apperNextTime)
        {
            SpawnEnemy();
            //Debug.Log(apperNextTime);
        }
        

    }

    public void SpawnEnemy()
    {
        //Debug.Log("Spawn");
        //spawn_angle = spawn_rnd.Next(360);
        spawn_angle = UnityEngine.Random.Range(20, 70);

        spawn_x = spawn_distance * Math.Cos(spawn_angle * (Math.PI / 180));
        spawn_z = spawn_distance * Math.Sin(spawn_angle * (Math.PI / 180));

        GameObject spawn_object = Resources.Load("Enemy") as GameObject;
        GameObject spawn_instance = Instantiate(spawn_object, new Vector3((float)spawn_x, spawn_height,(float)spawn_z), Quaternion.identity, this.transform);
        numberOfEnemys++;
        elapsedTime = 0f;
    }
}