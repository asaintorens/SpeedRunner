using UnityEngine;
using System.Collections;
using Assets.MyAssets.Resources.Script.database;
using System.Collections.Generic;
using Assets.MyAssets.Resources.Script.model;
using System.Linq;

public class MenuScoreboardScript : MonoBehaviour {


    public GameObject GlobalRankingScrollContent;
    public GameObject PrefabScore;

    public GameObject PanelGlobalRanking;
    public GameObject PanelMyStats;
    public UnityEngine.UI.Button ButtonGlobalRanking;
    public UnityEngine.UI.Button ButtonMyStats;
    public UnityEngine.UI.Scrollbar scrollbarGlobalRanking;

    public UnityEngine.UI.Scrollbar scrollbarMyStats;
    public GameObject MyStatsScrollContent;

    public UnityEngine.UI.Text bestScoreText;
    public UnityEngine.UI.Text totalGamesText;

    public GameObject sampleScore;


    public List<ModelScore> globalScores = new List<ModelScore>();
    
	// Use this for initialization
	public void Init () {

        this.StartCoroutine("CoroutineLoadGlobalRanking");
        this.StartCoroutine("CoroutineLoadMyStats");
        this.PanelGlobalRanking.SetActive(true);
        this.PanelMyStats.SetActive(false);
        this.ButtonGlobalRanking.interactable = false;
        this.ButtonMyStats.interactable = true;
    }
	


    public IEnumerator CoroutineLoadMyStats()
    {
       List<int> scores= PlayerPrefsManager.GetScores();
        this.bestScoreText.text = scores.Max().ToString();
        this.totalGamesText.text = scores.Count().ToString();


        foreach (Transform oneChild in MyStatsScrollContent.transform)
        {
            Destroy(oneChild.gameObject);
        }
        foreach(int oneScore in scores)
        {
            GameObject scoreText = Instantiate(sampleScore);
            scoreText.transform.SetParent(MyStatsScrollContent.transform);
            scoreText.GetComponent<UnityEngine.UI.Text>().text = oneScore.ToString();
        }

        this.scrollbarMyStats.value = 1;
        yield return null;
    }
    public IEnumerator CoroutineLoadGlobalRanking()
    {
        this.StopCoroutine("CoroutineFillGlobalRankingScore");
        ManagerDB.LunchGetGlobalScore();
        ManagerDB.CheckIsDone();

        while(!ManagerDB.isDone)
        {
            Debug.Log("wait");
            yield return new WaitForSeconds(0.5f);
            ManagerDB.CheckIsDone();
        }

        this.globalScores = ManagerDB.GetModels();

        this.StartCoroutine("CoroutineFillGlobalRankingScore");
        yield return null;
    }

    public IEnumerator CoroutineFillGlobalRankingScore()
    {
        int indexChild = 0;
        foreach(Transform child in this.GlobalRankingScrollContent.transform)
        {
            if(indexChild != 0)
            { 
                //DO NOT DESTROY THE HEADER
            Destroy(child.gameObject);
            }
            indexChild++;
        }

        int position = 1;
        foreach (ModelScore oneScore in this.globalScores)
        {
            GameObject myScore =   Instantiate(this.PrefabScore);
            myScore.transform.SetParent(this.GlobalRankingScrollContent.transform);
            ScorePanel scorePanel = myScore.GetComponent<ScorePanel>();
            scorePanel.score = oneScore.score.ToString();
            scorePanel.username = oneScore.name;
            scorePanel.position = position.ToString();

            scorePanel.InitText();
            position++;

        }

        this.scrollbarGlobalRanking.value = 1;

        yield return null;
    }

    public void ClickButtonGlobalStats()
    {
        this.PanelGlobalRanking.SetActive(true);
        this.PanelMyStats.SetActive(false);

        this.ButtonGlobalRanking.interactable = false;
        this.ButtonMyStats.interactable = true;
    }

    public void ClickButtonMyStats()
    {
        this.PanelGlobalRanking.SetActive(false);
        this.PanelMyStats.SetActive(true);

          this.ButtonGlobalRanking.interactable = true;
        this.ButtonMyStats.interactable = false;
        this.scrollbarMyStats.value = 1;
    }
}
