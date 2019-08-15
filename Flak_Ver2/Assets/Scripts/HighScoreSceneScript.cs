using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HighScoreSceneScript : MonoBehaviour {

    public Text HighScoreLabel;

    public static string RankingPref;
    public static int RankingNum = 5;
    public static int[] Ranking;

    public void Start()
    {
        getRanking();

        HighScoreLabel.text = "1位 : " + +Ranking[0] + "\n2位 : " + Ranking[1] + "\n3位 : " + Ranking[2] + "\n4位 : " + Ranking[3] + "\n5位 : " + Ranking[4];

    }

    public void BackTitleHighScoreButtonFunc()
    {
        SceneManager.LoadScene("Start");
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

    public void deleteRanking()
    {
        PlayerPrefs.DeleteKey(RankingPref);
    }
}
