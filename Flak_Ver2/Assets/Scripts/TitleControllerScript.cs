using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TitleControllerScript : MonoBehaviour{

    public GameObject SoundManager;
    SoundScript soundScript;

    int cursornum = 0;

    public Image[] SelectCursor;



    public void Start()
    {
        string originalRankingTitle = PlayerPrefs.GetString(HighScoreSceneScript.RankingPref, "0,0,0,0,0");

        soundScript = SoundManager.GetComponent<SoundScript>();

        cursornum = 0;

        SelectCursor[0].gameObject.SetActive(true);
        SelectCursor[1].gameObject.SetActive(false);
        SelectCursor[2].gameObject.SetActive(false);
        SelectCursor[3].gameObject.SetActive(false);

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
        GetComponent<DifficultLevelScript>().set0();
        SceneManager.LoadScene("GameScene");
    }
    public void Startbutton1()
    {
        soundScript.DecideSound1();
        GetComponent<DifficultLevelScript>().set1();
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
        if (Input.GetKeyDown(KeyCode.Return))
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

        SelectCursor[cursornum].gameObject.SetActive(true);
        SelectCursor[(cursornum + 1) % 4].gameObject.SetActive(false);
        SelectCursor[(cursornum + 2) % 4].gameObject.SetActive(false);
        SelectCursor[(cursornum + 3) % 4].gameObject.SetActive(false);

    }

    public void CursorDown()
    {
        if (cursornum < 3) cursornum++;

        soundScript.DecideSound2();

        SelectCursor[cursornum].gameObject.SetActive(true);
        SelectCursor[(cursornum + 1) % 4].gameObject.SetActive(false);
        SelectCursor[(cursornum + 2) % 4].gameObject.SetActive(false);
        SelectCursor[(cursornum + 3) % 4].gameObject.SetActive(false);

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