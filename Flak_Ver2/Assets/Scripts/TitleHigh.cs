using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TitleHigh : MonoBehaviour
{

    public GameObject BGMManager;
    SoundScript soundScript;

    public Image SelectCursor0;




    public void Start()
    {
        string originalRankingTitle = PlayerPrefs.GetString(HighScoreSceneScript.RankingPref, "0,0,0,0,0");

        soundScript = BGMManager.GetComponent<SoundScript>();


        SelectCursor0.gameObject.SetActive(true);

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



    void Update()
    {

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

    

    public void CursorEnter()
    {
        soundScript.DecideSound3();
        SceneManager.LoadScene("Start");

    }


}

