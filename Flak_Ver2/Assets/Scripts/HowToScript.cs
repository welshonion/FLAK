using UnityEngine.SceneManagement;
using UnityEngine;

public class HowToScript : MonoBehaviour {

    // Use this for initialization
    void Start() {
        Invoke("HowToVoid", 15.0f);
    }
    
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Fire1"))
        {
            HowToVoid();
        }
    }

    void HowToVoid()
    {
        SceneManager.LoadScene("Game");
    }
}
