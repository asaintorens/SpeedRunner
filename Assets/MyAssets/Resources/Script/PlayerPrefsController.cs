using UnityEngine;
using System.Collections;

public class PlayerPrefsController : MonoBehaviour {

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
}
