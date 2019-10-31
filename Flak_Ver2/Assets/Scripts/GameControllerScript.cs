using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameControllerScript : MonoBehaviour
{


    GameObject[] tagObjects;
    float timer = 0.0f;
    float interval = 2.0f;



    public enum State
    {
        Ready,
        Play,
        GameOver
    }

    public State state;
    int score;

    //public HumanController human;
    ///public GameObject blocks;
    public EnemyScript enemy;
    public Text scoreLabel;
    public Text stateLabel;
    public GameObject Pause;
    public GameObject PauseBackGame;
    public Button BackGameButton;
    public Image SelectCursor0;
    public Image SelectCursor1;
    public Image SelectCursor2;
    public bool StateGCS;//if true then move else stop
    public static bool TweetBool;

    int ScoreSpace;
    int ScoreForRanking;
    int ScoreForRankingTmp;

    bool jud_gameover;


    //Hassyaon
    AudioSource BGMSource;
    public AudioClip AudioStart;

    StopScreen stopScreen;
    public GameObject BGMManager;
    SoundScript soundScript;

    bool jud_pause=false;

    int cursornum = 0;

    public static string RankingPref;
    public static int RankingNum = 5;
    public static int[] Ranking;

    public GameObject deathCamera;


    //   public static bool stopscreen = false;

    // Use this for initialization
    // Start is called before the first frame update
    void Start()
    {
        Ready();
        BGMSource = GetComponent<AudioSource>();
        stopScreen = Pause.GetComponent<StopScreen>();
        soundScript = BGMManager.GetComponent<SoundScript>();
        deathCamera.SetActive(false);
        jud_pause = false;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        switch (state)
        {
            case State.Ready:
                if (Input.GetKeyDown(KeyCode.Return)||Input.touchCount>0)
                {
                    jud_gameover = false;
                    GameStart();
                }
                break;
            case State.Play:
                if (jud_gameover)
                {
                    Debug.Log("switch_gameover");
                    GameOver();
                }
                break;

        }

    }

    void Ready()
    {
        state = State.Ready;

        ////////human.SetSteerActive(false);
        //       blocks.SetActive(false);

        scoreLabel.text = "Score : " + 0;

        BackGameButton.gameObject.SetActive(false);
        SelectCursor0.gameObject.SetActive(false);
        SelectCursor1.gameObject.SetActive(false);
        SelectCursor2.gameObject.SetActive(false);

        stateLabel.gameObject.SetActive(true);
        stateLabel.text = "Press Enter Button";
        StateGCS = false;
        TweetBool = false;
        cursornum = 0;

        Time.timeScale = 0;
    }

    void GameStart()
    {
        state = State.Play;

        Time.timeScale = 1;

        //////human.SetSteerActive(true);
        //        blocks.SetActive(true);

        //BGMSource.PlayOneShot(AudioStart);

        stateLabel.gameObject.SetActive(false);
        stateLabel.text = "";

        StateGCS = true;
    }

    public void Stop()
    {
        if (state == State.GameOver)
        {
            Retry();
        }
        else
        {
            stateLabel.gameObject.SetActive(true);
            stateLabel.text = "Pause";
            BackGameButton.gameObject.SetActive(true);
            SelectCursor0.gameObject.SetActive(true);

            BGMSource.Pause();
            StateGCS = false;

            Time.timeScale = 0;
        }

    }

    public void Backgame()
    {
        Time.timeScale = 1;

        stopScreen.BackPause();
        soundScript.DecideSound1();

        BGMSource.UnPause();
        StateGCS = true;

        stateLabel.gameObject.SetActive(false);
        BackGameButton.gameObject.SetActive(false);
        SelectCursor0.gameObject.SetActive(false);
        SelectCursor1.gameObject.SetActive(false);
        SelectCursor2.gameObject.SetActive(false);
    }

    public void Backtitle()
    {
        Time.timeScale = 1;
        soundScript.DecideSound3();
        SceneManager.LoadScene("Start");
    }

    void GameOver()
    {
        state = State.GameOver;

        ///////ScrollObject[] scrollObjects = GameObject.FindObjectsOfType<ScrollObject>();

        /////foreach (ScrollObject so in scrollObjects) so.enabled = false;
        ///     

        StateGCS = false;
        BGMSource.Pause();
        TweetBool = true;
        cursornum = 1;

        Pause.gameObject.SetActive(true);
        stateLabel.gameObject.SetActive(true);
        stateLabel.text = "GameOver";
        SelectCursor0.gameObject.SetActive(false);
        SelectCursor1.gameObject.SetActive(true);
        SelectCursor2.gameObject.SetActive(false);

        ScoreForRanking = score;

        getRanking();

        

        for (int m = 0; m < 5; m++)
        {
            if (ScoreForRanking > Ranking[m])
            {
                ScoreForRankingTmp = Ranking[m];

                Ranking[m] = ScoreForRanking;

                ScoreForRanking = ScoreForRankingTmp;
            }

        }

        PlayerPrefs.SetString(RankingPref, Ranking[0].ToString() + "," + Ranking[1].ToString() + "," + Ranking[2].ToString() + "," + Ranking[3].ToString() + "," + Ranking[4].ToString());

        Invoke("Backtitle", 20.0f);
    }

    


    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > interval)
        {
            Check("EnemyTag");
            timer = 0;
        }

        if (Input.GetKeyDown(KeyCode.Space) && state != State.Ready)
        {
            push_pause();
        }

        /*if (Input.GetKeyDown(KeyCode.P))
        {
            Stop();
        }*/

        if (StateGCS == false&&Input.GetKeyDown(KeyCode.I)&&state != State.Ready)
        {
            CursorUp();
        }
        if (StateGCS == false && Input.GetKeyDown(KeyCode.J) && state != State.Ready)
        {
            CursorDown();
        }
        if (StateGCS == false && Input.GetKeyDown(KeyCode.Return) && state != State.Ready)
        {
            CursorEnter();
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            soundScript.DecideSound3();
            Application.Quit();
        }


    }


    void Check(string tagname)
    {
        tagObjects = GameObject.FindGameObjectsWithTag(tagname);
        //Debug.Log(tagObjects.Length);

    }

    public void Retry()
    {
        Time.timeScale = 1;

        soundScript.DecideSound1();

        Pause.gameObject.SetActive(false);
        PauseBackGame.gameObject.SetActive(false);
        TweetBool = false;
        //       Application.LoadLevel(Application.loadedLevel);
        SceneManager.LoadScene("GameScene");
    }

    public void IncreaseScore()
    {
        score += 100;
        scoreLabel.text = "Score : " + score;
    }

    public void Jud_GameOver()
    {
        jud_gameover = true;
    }

    public void push_pause()
    {
        if (jud_pause == false)
        {
            Stop();
            stopScreen.Pause();
            soundScript.DecideSound2();
            jud_pause = true;
        }
        else if(jud_pause ==true)
        {
            Backgame();
            stopScreen.BackPause();
            soundScript.DecideSound1();
            jud_pause = false;
        }
        
    }

    public void CursorUp()
    {
        if (cursornum > 0) cursornum--;

        soundScript.DecideSound2();

        if (cursornum == 0)
        {
            SelectCursor0.gameObject.SetActive(true);
            SelectCursor1.gameObject.SetActive(false);
            SelectCursor2.gameObject.SetActive(false);
        }
        else if (cursornum == 1)
        {
            SelectCursor0.gameObject.SetActive(false);
            SelectCursor1.gameObject.SetActive(true);
            SelectCursor2.gameObject.SetActive(false);
        }
        else if (cursornum == 2)
        {
            SelectCursor0.gameObject.SetActive(false);
            SelectCursor1.gameObject.SetActive(false);
            SelectCursor2.gameObject.SetActive(true);
        }
    }
    public void CursorDown()
    {
        if (cursornum < 2) cursornum++;

        soundScript.DecideSound2();

        if (cursornum == 0)
        {
            SelectCursor0.gameObject.SetActive(true);
            SelectCursor1.gameObject.SetActive(false);
            SelectCursor2.gameObject.SetActive(false);
        }
        else if (cursornum == 1)
        {
            SelectCursor0.gameObject.SetActive(false);
            SelectCursor1.gameObject.SetActive(true);
            SelectCursor2.gameObject.SetActive(false);
        }
        else if (cursornum == 2)
        {
            SelectCursor0.gameObject.SetActive(false);
            SelectCursor1.gameObject.SetActive(false);
            SelectCursor2.gameObject.SetActive(true);
        }
    }
    public void CursorEnter()
    {
        if (cursornum == 0&&state != State.GameOver)
        {
            Backgame();
        }
        else if (cursornum == 1)
        {
            Retry();
        }
        else if (cursornum == 2)
        {
            Backtitle();
        }
    }

    void getRanking()
    {
        string originalRanking = PlayerPrefs.GetString(RankingPref, "0,0,0,0,0");

        if (originalRanking.Length > 0)
        {
            string[] RankingScore = originalRanking.Split(","[0]);

            Ranking = new int[RankingNum];

            for (int k = 0; k < originalRanking.Length && k < RankingNum; k++)
            {
                Ranking[k] = int.Parse(RankingScore[k]);
            }
        }
    }

    public void active_deathCamera()
    {
        deathCamera.SetActive(true);
    }

}

