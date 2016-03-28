using UnityEngine;
using System.Collections;
using Assets.MyAssets.Resources.Script.database;
using Assets.MyAssets.Resources.Script.model;
using System.Collections.Generic;

public class ManagerDBTest : MonoBehaviour
{

    public bool AddScore;
    public bool AddGame;
    public bool GetScore;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (AddScore)
        {
            AddScore = false;
            this.StartCoroutine("AddScoreToDB");
        }
        if(GetScore)
        {
            this.GetScore = false;
            this.StartCoroutine("CoroutineGetScore");
        }
    }

    public IEnumerator CoroutineGetScore()
    {
        ManagerDB.LunchGetGlobalScore();
        ManagerDB.CheckIsDone();

        while (!ManagerDB.isDone)
        {
            yield return new WaitForSeconds(0.5f);
            ManagerDB.CheckIsDone();
        }

        List<ModelScore> listScores = ManagerDB.GetModels();

        yield return null;


    }

    public IEnumerator AddScoreToDB()
    {
        ManagerDB.debugOption = true;
        ManagerDB.AddScoreToApi("test10", -1);
        return null;
    }

}

