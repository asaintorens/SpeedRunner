using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using System;
using Assets.MyAssets.Resources.Script;

public class MenuController : MonoBehaviour
{


    public GameObject MenuPrincipalLayout;
    public GameObject OptionLayout;
    public GameObject ScoreBoardLayout;
    public GameObject RootPanel;


    public MenuScoreboardScript scoreBoard;
    // Use this for initialization
    void Start()
    {
        Time.timeScale = 1;
        this.ReturnToMainMenu();
        this.InitQuality();
    }

    private void ReturnToMainMenu()
    {
        foreach (Transform onePanel in RootPanel.transform)
        {
            onePanel.gameObject.SetActive(false);
        }

        this.MenuPrincipalLayout.SetActive(true);
    }

    private void InitQuality()
    {
        String quality = PlayerPrefs.GetString(PlayerPrefsString.QUALITY_SETTINGS);
        if (quality != "")
        {
            QualitySettings.SetQualityLevel(int.Parse(quality));
        }
    }

    public void StartGame()
    {
        SceneManager.UnloadScene("game");

        SceneManager.LoadScene("game");
    }

    public void OptionsMenuClick()
    {
        this.MenuPrincipalLayout.SetActive(false);
        this.OptionLayout.SetActive(true);
    }

    public void ReturnToGlobalMenu()
    {
        this.ReturnToMainMenu();
    }
    public void ScoreBoardMenuClick()
    {
        this.MenuPrincipalLayout.SetActive(false);
        this.ScoreBoardLayout.SetActive(true);

        this.scoreBoard.Init();
    }
}
