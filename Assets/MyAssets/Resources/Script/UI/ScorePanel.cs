using UnityEngine;
using System.Collections;

public class ScorePanel : MonoBehaviour {


    public string username;
    public string score;
    public string position;

    public UnityEngine.UI.Text positionText;
    public UnityEngine.UI.Text nameText;
    public UnityEngine.UI.Text scoreText;
    // Use this for initialization
    public void InitText () {

        positionText.text = position.ToString();
        nameText.text = username;
        scoreText.text = score.ToString();

	}
	
	// Update is called once per frame

}
