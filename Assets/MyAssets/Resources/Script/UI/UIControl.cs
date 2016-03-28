using UnityEngine;
using System.Collections;
using System;
using Assets.MyAssets.Resources.Script;

public class UIControl : MonoBehaviour
{

    public Game game;
    public UnityEngine.UI.Text textScore;
    public UnityEngine.UI.Text timeScale;
    public UnityEngine.UI.Button buttonStart;
    public UnityEngine.UI.Text inputName;
    public UnityEngine.UI.Button buttonMusic;
    public GameObject ButtonPanel;
    public GameObject panelNickName;
    // Use this for initialization
    void Start()
    {
        if (ButtonPanel != null)
            this.InitButtonSmartPhone();
    }

    private void InitButtonSmartPhone()
    {

        ButtonPanel.SetActive(PlayerPrefs.GetString(PlayerPrefsString.INPUT_SMARTPHONE) == PlayerPrefsString.TRUE);
        
    }

    public void EnablePlayerWriteName()
    {
        this.panelNickName.SetActive(true);
    }

    public void ValidateName()
    {
        if(this.inputName.text != "")
        {
            PlayerPrefs.SetString("name", this.inputName.text);
            this.ClosePlayerWriteName();
        }

    }

    private void ClosePlayerWriteName()
    {
        this.panelNickName.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(this.textScore != null)
        this.textScore.text = game.score.ToString();
        if(this.timeScale != null)
        this.timeScale.text = Time.timeScale.ToString(); ;
    }

    public void MusicButton()
    {
        if (game.audio.mute)
        {
            this.game.audio.mute = false;
            PlayerPrefs.SetInt("music", 1);
        }
        else
        {
            game.audio.mute = true;
            PlayerPrefs.SetInt("music", 0);
        }
        this.SetAudioButton();
      
    }

    

    public void RestartGame()
    {
        this.game.RestartGame();
    }

    public void StartGame()
    {
        this.game.StartGame();
        this.HideStartButton();
    }

    internal void SetAudioButton()
    {
        if (this.buttonMusic != null)
        {
            this.buttonMusic.GetComponentInChildren<UnityEngine.UI.Text>().text = this.game.audio.mute ? "Music : Off" : "Music : On";
        }
    }
    public void HideStartButton()
    {
        this.buttonStart.gameObject.SetActive(false);
    }

     public void ButtonUp()
    {
        this.game.logicAnimator.Jump();
    }

    public void ButtonDown()
    {
        this.game.logicAnimator.Slide();
    }

    public void ButtonLeft()
    {
        this.game.logicAnimator.Enforce();
    }

    public void ButtonRight()
    {
        this.game.logicAnimator.Spear();
    }
}
