using UnityEngine;

public class ScrollObject : MonoBehaviour {

    //ForGameState***ReadOnly***
    GameObject gameController;
    GameControllerScript gameControllerScript;
    public State state;

    public float speed = 1.0f;
    public float startPosition;
    public float endPosition;
    public float firstPosition;  

    public double acceltime;
    double firsttime;

    private void Start()
    {
        gameController = GameObject.FindWithTag("GameController");
        if (gameController != null)
        {
            gameControllerScript = gameController.GetComponent<GameControllerScript>();
        }
        else
        {
            state = State.Ready;
        }


        transform.Translate(firstPosition, 0, 0);
    }

    // Update is called once per frame
    void Update () {

        if (gameController != null)
        {
            state = gameControllerScript.state;
        }

        transform.Translate(-1 * speed * Time.deltaTime * ((float)acceltime + (float)firsttime), 0, 0);

        if (transform.position.x <= endPosition) ScrollEnd();

        //       Debug.Log(accelbool);

        if (state == State.Play && firsttime <= 0.6)
        {
            firsttime += 0.2 * Time.deltaTime;
        }
        else if(state == State.Play)
        {
            acceltime += 0.01 * Time.deltaTime;
        }
        else{
            acceltime = 0;
        }


    }

    void ScrollEnd()
    {

        transform.Translate(-1 * (endPosition - startPosition), 0, 0);

        SendMessage("OnScrollEnd", SendMessageOptions.DontRequireReceiver);

    }

}
