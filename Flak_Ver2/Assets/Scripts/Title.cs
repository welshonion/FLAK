using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Title : MonoBehaviour {


    public void Start()
    {
        string originalRankingTitle = PlayerPrefs.GetString(HighScoreSceneScript.RankingPref, "0,0,0,0,0");

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

    public void Startbutton()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void Endbutton()
    {
        Application.Quit();
    }

    public void HighScoreFank()
    {
        SceneManager.LoadScene("HighScoreScene");
    }


}
