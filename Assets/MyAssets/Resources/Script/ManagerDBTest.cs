using UnityEngine;
using System.Collections;
using Assets.MyAssets.Resources.Script.database;

public class ManagerDBTest : MonoBehaviour
{

    public bool AddScore;
    public bool AddGame;
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
    }

    public IEnumerator AddScoreToDB()
    {
        ManagerDB.debugOption = true;
        ManagerDB.AddScoreToApi("test10", -1);
        return null;
    }

}

