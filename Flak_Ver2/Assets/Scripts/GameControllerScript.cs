using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public enum State
{
    Ready = 0,
    Play = 1,
    Pause = 2,
    GameOver = 3
}

public class GameControllerScript : MonoBehaviour
{
    //ForGameState
    /*public enum State
    {
        Ready,
        Play,
        Pause,
        GameOver
    }*/

    public State state;

    bool jud_gameover;

    public bool jud_pause = false;

    public GameObject deathCamera;


    //ForPlayingBGM
    AudioSource BGMSource;
    public AudioClip bgm;

    //UI related Objects
    public GameObject window;
    WindowActiveScript windowActiveScript;
    public Text scoreLabel;
    public Text stateLabel;
    public Button BackGameButton;

    int cursornum = 0;

    public Image[] SelectCursor;

    //ForScore
    int score;
    int scoreForRanking;
    int scoreForRankingTmp;

    public static string RankingPref;
    public static int RankingNum = 5;
    public static int[] Ranking;

    //ForSound
    public GameObject SoundManager;
    SoundScript soundScript;

    //   public static bool windowActiveScript = false;

    // Use this for initialization
    // Start is called before the first frame update
    void Start()
    {
        BGMSource = GetComponent<AudioSource>();
        windowActiveScript = window.GetComponent<WindowActiveScript>();
        soundScript = SoundManager.GetComponent<SoundScript>();
        deathCamera.SetActive(false);
        Ready();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space) && state != State.Ready)
        {
            push_pause();
        }

        /*if (Input.GetKeyDown(KeyCode.P))
        {
            Stop();
        }*/

        if ((state == State.Pause || state == State.GameOver) && Input.GetKeyDown(KeyCode.I))
        {
            CursorUp();
        }
        if ((state == State.Pause || state == State.GameOver) && Input.GetKeyDown(KeyCode.J))
        {
            CursorDown();
        }
        if ((state == State.Pause || state == State.GameOver) && Input.GetKeyDown(KeyCode.Return))
        {
            CursorEnter();
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            soundScript.DecideSound3();
            Application.Quit();
        }


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
                    Play();
                }
                break;
            case State.Play:
                if (jud_gameover)
                {
                    //Debug.Log("switch_gameover");
                    GameOver();
                }
                break;
        }

    }

    void Ready()
    {
        state = State.Ready;

        scoreLabel.text = "Score : " + 0;

        BackGameButton.gameObject.SetActive(false);
        SelectCursor[0].gameObject.SetActive(false);
        SelectCursor[1].gameObject.SetActive(false);
        SelectCursor[2].gameObject.SetActive(false);

        stateLabel.gameObject.SetActive(true);
        stateLabel.text = "Press Enter Button";
        cursornum = 0;

        Time.timeScale = 0;
    }

    void Play()
    {
        state = State.Play;

        Time.timeScale = 1;

        //BGMSource.PlayOneShot(bgm);

        stateLabel.gameObject.SetActive(false);
        stateLabel.text = "";
    }

    public void Pause()
    {
        if (state == State.GameOver)
        {
            Retry();
        }
        else
        {
            state = State.Pause;

            stateLabel.gameObject.SetActive(true);
            stateLabel.text = "Pause";
            BackGameButton.gameObject.SetActive(true);
            SelectCursor[0].gameObject.SetActive(true);

            BGMSource.Pause();

            Time.timeScale = 0;
        }

    }

    public void push_pause()
    {
        if (state == State.Play)
        {
            windowActiveScript.Active();
            soundScript.DecideSound2();
            Pause();
        }
        else
        {
            windowActiveScript.Hidden();
            soundScript.DecideSound1();
            Backgame();
        }

    }

    public void Backgame()
    {
        state = State.Play;

        Time.timeScale = 1;

        windowActiveScript.Hidden();
        soundScript.DecideSound1();

        BGMSource.UnPause();

        stateLabel.gameObject.SetActive(false);
        BackGameButton.gameObject.SetActive(false);
        SelectCursor[0].gameObject.SetActive(false);
        SelectCursor[1].gameObject.SetActive(false);
        SelectCursor[2].gameObject.SetActive(false);
    }

    public void Backtitle()
    {
        Time.timeScale = 1;
        soundScript.DecideSound3();
        getRanking();
        setRanking();
        SceneManager.LoadScene("Start");
    }

    void GameOver()
    {
        state = State.GameOver;

        ///////ScrollObject[] scrollObjects = GameObject.FindObjectsOfType<ScrollObject>();

        /////foreach (ScrollObject so in scrollObjects) so.enabled = false;
        ///     

        BGMSource.Pause();
        cursornum = 1;

        window.gameObject.SetActive(true);
        stateLabel.gameObject.SetActive(true);
        stateLabel.text = "GameOver";
        SelectCursor[0].gameObject.SetActive(false);
        SelectCursor[1].gameObject.SetActive(true);
        SelectCursor[2].gameObject.SetActive(false);

        getRanking();
        setRanking();
   
        Invoke("Backtitle", 20.0f);
    }

    public void Retry()
    {
        Time.timeScale = 1;

        soundScript.DecideSound1();

        window.gameObject.SetActive(false);

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


    public void CursorUp()
    {
        if (cursornum > 0 && state != State.GameOver) cursornum--;
        else if (cursornum > 1) cursornum--;

        soundScript.DecideSound2();

        SelectCursor[cursornum].gameObject.SetActive(true);
        SelectCursor[(cursornum + 1) % 3].gameObject.SetActive(false);
        SelectCursor[(cursornum + 2) % 3].gameObject.SetActive(false);

    }
    public void CursorDown()
    {
        if (cursornum < 2) cursornum++;

        soundScript.DecideSound2();

        SelectCursor[cursornum].gameObject.SetActive(true);
        SelectCursor[(cursornum + 1) % 3].gameObject.SetActive(false);
        SelectCursor[(cursornum + 2) % 3].gameObject.SetActive(false);

    }
    public void CursorEnter()
    {
        if (cursornum == 0 && state != State.GameOver) Backgame();
        else if (cursornum == 1) Retry();
        else if (cursornum == 2) Backtitle();

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

    void setRanking()
    {
        scoreForRanking = score;

        for (int m = 0; m < 5; m++)
        {
            if (scoreForRanking > Ranking[m])
            {
                scoreForRankingTmp = Ranking[m];

                Ranking[m] = scoreForRanking;

                scoreForRanking = scoreForRankingTmp;
            }

        }

        PlayerPrefs.SetString(RankingPref, Ranking[0].ToString() + "," + Ranking[1].ToString() + "," + Ranking[2].ToString() + "," + Ranking[3].ToString() + "," + Ranking[4].ToString());

        score = 0;
    }

    public void active_deathCamera()
    {
        deathCamera.SetActive(true);
    }

}

