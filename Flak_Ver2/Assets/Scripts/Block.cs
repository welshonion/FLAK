using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour {

    public float minHeight;
    public float maxHeight;
    public GameObject pivot;
    public GameObject biru1, biru2, biru3, biru4, biru5, biru6, biru7, biru8;

    int randomnum;

	// Use this for initialization
	void Start () {

        ChangeHeight();
        ChangeBuilding();

    }

    void ChangeHeight()
    {
        float height = Random.Range(minHeight, maxHeight);
        pivot.transform.localPosition = new Vector3(0.0f, height, 0.0f);
        
    }

    void ChangeBuilding()
    {
        biru1.gameObject.SetActive(false);
        biru2.gameObject.SetActive(false);
        biru3.gameObject.SetActive(false);
        biru4.gameObject.SetActive(false);
        biru5.gameObject.SetActive(false);
        biru6.gameObject.SetActive(false);
        biru7.gameObject.SetActive(false);
        biru8.gameObject.SetActive(false);
        randomnum = Random.Range(1, 15);

        if (randomnum == 1)
        {
            biru1.gameObject.SetActive(true);
        }
        else if(randomnum == 2)
        {
            biru2.gameObject.SetActive(true);
        }
        else if (randomnum == 3)
        {
            biru3.gameObject.SetActive(true);
        }
        else if (randomnum == 4)
        {
            biru4.gameObject.SetActive(true);
        }
        else if (randomnum == 5)
        {
            biru5.gameObject.SetActive(true);
        }
        else if (randomnum == 6)
        {
            biru6.gameObject.SetActive(true);
        }
        else if (randomnum == 7)
        {
            biru7.gameObject.SetActive(true);
        }
        else if (randomnum == 8)
        {
            biru8.gameObject.SetActive(true);
        }



    }

    void OnScrollEnd ()
    {
        ChangeHeight();
        ChangeBuilding();

	}
}
