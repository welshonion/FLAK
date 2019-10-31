using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Title : MonoBehaviour {

    public GameObject BGMManager;
    SoundScriptStart soundScript;

    public Image SelectCursor0;
    public Image SelectCursor1;
    public Image SelectCursor2;
    public Image SelectCursor3;

    int cursornum = 0;



    public void Start()
    {
        string originalRankingTitle = PlayerPrefs.GetString(HighScoreSceneScript.RankingPref, "0,0,0,0,0");

        soundScript = BGMManager.GetComponent<SoundScriptStart>();

        cursornum = 0;

        SelectCursor0.gameObject.SetActive(true);
        SelectCursor1.gameObject.SetActive(false);
        SelectCursor2.gameObject.SetActive(false);
        SelectCursor3.gameObject.SetActive(false);

        if (originalRankingTitle.Length > 0)
        {
            string[] RankingScore = originalRankingTitle.Split(","[0]);

            HighScoreSceneScript.Ranking = new int[HighScoreSceneScript.RankingNum];

            for (int k = 0; k < originalRankingTitle.Length && k < HighScoreSceneScript.RankingNum; k++)
            {
                HighScoreSceneScript.Ranking[k] = int.Parse(RankingScore[k]);
            }
        }
    }

    public void Startbutton0()
    {
        soundScript.DecideSound1();
        GetComponent<DifficultLevel>().set0();
        SceneManager.LoadScene("GameScene");
    }
    public void Startbutton1()
    {
        soundScript.DecideSound1();
        GetComponent<DifficultLevel>().set1();
        SceneManager.LoadScene("GameScene");
    }

    public void Endbutton()
    {
        soundScript.DecideSound3();
        Application.Quit();
    }

    public void HighScoreFank()
    {
        soundScript.DecideSound1();
        SceneManager.LoadScene("HighScoreScene");
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            CursorUp();
        }
        if (Input.GetKeyDown(KeyCode.J))
        {
            CursorDown();
        }
        if ( Input.GetKeyDown(KeyCode.Return))
        {
            CursorEnter();
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            soundScript.DecideSound3();
            Application.Quit();
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
            SelectCursor3.gameObject.SetActive(false);
        }
        else if (cursornum == 1)
        {
            SelectCursor0.gameObject.SetActive(false);
            SelectCursor1.gameObject.SetActive(true);
            SelectCursor2.gameObject.SetActive(false);
            SelectCursor3.gameObject.SetActive(false);
        }
        else if (cursornum == 2)
        {
            SelectCursor0.gameObject.SetActive(false);
            SelectCursor1.gameObject.SetActive(false);
            SelectCursor2.gameObject.SetActive(true);
            SelectCursor3.gameObject.SetActive(false);
        }
        else if (cursornum == 3)
        {
            SelectCursor0.gameObject.SetActive(false);
            SelectCursor1.gameObject.SetActive(false);
            SelectCursor2.gameObject.SetActive(false);
            SelectCursor3.gameObject.SetActive(true);
        }

    }
    public void CursorDown()
    {
        if (cursornum < 3) cursornum++;

        soundScript.DecideSound2();

        if (cursornum == 0)
        {
            SelectCursor0.gameObject.SetActive(true);
            SelectCursor1.gameObject.SetActive(false);
            SelectCursor2.gameObject.SetActive(false);
            SelectCursor3.gameObject.SetActive(false);
        }
        else if (cursornum == 1)
        {
            SelectCursor0.gameObject.SetActive(false);
            SelectCursor1.gameObject.SetActive(true);
            SelectCursor2.gameObject.SetActive(false);
            SelectCursor3.gameObject.SetActive(false);
        }
        else if (cursornum == 2)
        {
            SelectCursor0.gameObject.SetActive(false);
            SelectCursor1.gameObject.SetActive(false);
            SelectCursor2.gameObject.SetActive(true);
            SelectCursor3.gameObject.SetActive(false);
        }
        else if (cursornum == 3)
        {
            SelectCursor0.gameObject.SetActive(false);
            SelectCursor1.gameObject.SetActive(false);
            SelectCursor2.gameObject.SetActive(false);
            SelectCursor3.gameObject.SetActive(true);
        }
    }

    public void CursorEnter()
    {
        if (cursornum == 0)
        {
            Startbutton0();
        }
        else if (cursornum == 1)
        {
            Startbutton1();
        }
        else if (cursornum == 2)
        {
            HighScoreFank();
        }
        else if (cursornum == 3)
        {
            Endbutton();
        }
    }


}
