using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using System;
using Assets.MyAssets.Resources.Script;

public class MenuController : MonoBehaviour
{


    public GameObject MenuPrincipalLayout;
    public GameObject OptionLayout;
    // Use this for initialization
    void Start()
    {
        Time.timeScale = 1;
        this.MenuPrincipalLayout.SetActive(true);
        this.OptionLayout.SetActive(false);
        this.InitQuality();
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
        SceneManager.LoadScene("Game");
    }

    public void OptionsMenuClick()
    {
        this.MenuPrincipalLayout.SetActive(false);
        this.OptionLayout.SetActive(true);
    }

    public void OptionsExitClick()
    {
        this.MenuPrincipalLayout.SetActive(true);
        this.OptionLayout.SetActive(false);
    }
}
