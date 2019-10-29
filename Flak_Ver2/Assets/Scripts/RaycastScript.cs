using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class RaycastScript : MonoBehaviour
{

    public float raser_distance_area = 200.0f;

    public Image rendray;
    float[] hoge = new float[360];
    public int angleinfo_ray = 0;


    GameObject[] enemyObjects;

    int jud_hit=0;
    int kakudo;
    float kyori;


    // Start is called before the first frame update
    void Start()
    {
        rendray = GameObject.Find("RadarImage").GetComponent<Image>();
        for (int i = 0; i < 360; i++)
        {
            hoge[i] = 0.0f;
        }
        rendray.material.SetFloatArray("_FDIST", hoge);

    }

    // Update is called once per frame
    void Update()
    {

        enemyObjects = GameObject.FindGameObjectsWithTag("EnemyTag");

        angleinfo_ray = ((int)(transform.localEulerAngles.y)  + 360) % 360;

        jud_hit = 0;

        foreach (GameObject enemyObject in enemyObjects)
        {
            Transform et = enemyObject.transform;
            Vector3 etp = et.position;

            kakudo = ((int)(Mathf.Atan2(etp.x, etp.z)*180/Mathf.PI)+360)%360;
            kyori = Mathf.Sqrt(Mathf.Pow(etp.x - this.transform.position.x, 2)
                + Mathf.Pow(etp.z - this.transform.position.z, 2));

           // Debug.Log("kakudo"+kakudo);

            if (angleinfo_ray >= (kakudo +358)%360 && angleinfo_ray <=(kakudo + 2)%360) 
            {
                //Debug.Log(hit.collider.gameObject.transform.position);
                //Debug.Log(angleinfo_ray);
                //Debug.Log(hit.distance);
                hoge[angleinfo_ray] = (kyori / raser_distance_area) - 2.0f;
                //Debug.Log(hoge[angleinfo_ray]);
                rendray.material.SetFloatArray("_FDIST", hoge);
                //Debug.Log("hitangle" + angleinfo_ray);
                jud_hit = 1;
                break;

            }

        }

        if (jud_hit == 0 && hoge[angleinfo_ray] != 0.0f)
        {
            hoge[angleinfo_ray] = 0.0f;
            rendray.material.SetFloatArray("_FDIST", hoge);
        }else if(jud_hit == 0)
        {
            hoge[angleinfo_ray] = 0.0f;
        }



        /*Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;





        angleinfo_ray = ((int)(transform.localEulerAngles.y) /*+ 180*//*) %360;
        //Debug.Log(angleinfo_ray);





        if (Physics.Raycast(ray, out hit, raser_distance_area))
        {
            //Debug.Log(hit.collider.gameObject.transform.position);
            //Debug.Log(angleinfo_ray);
            //Debug.Log(hit.distance);
            hoge[angleinfo_ray] = (hit.distance / raser_distance_area) - 2.0f;
            //Debug.Log(hoge[angleinfo_ray]);
            rendray.material.SetFloatArray("_FDIST", hoge);

        }
        else if(hoge[angleinfo_ray]!=0.0f)
        {
            hoge[angleinfo_ray] = 0.0f;
            rendray.material.SetFloatArray("_FDIST", hoge);
        }
        else
        {
            hoge[angleinfo_ray] = 0.0f;
        }



        //rendray.material.SetFloatArray("_FDIST", hoge);

        Debug.DrawRay(ray.origin, ray.direction*1000, Color.red, 3.0f);*/
    }
}
