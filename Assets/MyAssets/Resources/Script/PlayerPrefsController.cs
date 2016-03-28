using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;
using Assets.MyAssets.Resources.Script;

public class PlayerPrefsManager : MonoBehaviour {

    // Use this for initialization

    public string name = "";
    public int music;

    public bool resetPlayerPrefs;
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
        if(resetPlayerPrefs)
        {
            resetPlayerPrefs = false;
            PlayerPrefs.DeleteAll();
        }

        this.name = PlayerPrefs.GetString("name");
        this.music = PlayerPrefs.GetInt("music");

	}

    public static List<int> GetScores()
    {
        List<int> score = new List<int>();
        if(PlayerPrefs.GetString(PlayerPrefsString.SCORE) == "")
        {
            
        }
        else
        {
            string inputFromStorage = PlayerPrefs.GetString(PlayerPrefsString.SCORE);
            string[] scoreArray = inputFromStorage.Split('*');
            foreach(string oneScore in scoreArray)
            {
                score.Add(int.Parse(oneScore));
            }
            
        }

        return score;
    }

    public static void AddScore(string score)
    {
        if(PlayerPrefs.GetString(PlayerPrefsString.SCORE)=="")
        {
            PlayerPrefs.SetString(PlayerPrefsString.SCORE, score);
        }
        else
        {
            string actual = PlayerPrefs.GetString(PlayerPrefsString.SCORE);
            actual = actual + "*" + score;
            PlayerPrefs.SetString(PlayerPrefsString.SCORE, actual);
        }
    }
}
