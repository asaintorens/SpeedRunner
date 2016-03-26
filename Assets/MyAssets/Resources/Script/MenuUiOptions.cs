using UnityEngine;
using System.Collections;
using System;
using Assets.MyAssets.Resources.Script;

public class MenuUiOptions : MonoBehaviour
{


    public MenuController menu;

    public UnityEngine.UI.Button inputSmartPhoneYes;
    public UnityEngine.UI.Button inputSmartPhoneNo;

    public UnityEngine.UI.Button veryLow;
    public UnityEngine.UI.Button Low;
    public UnityEngine.UI.Button Medium;
    public UnityEngine.UI.Button high;
    public UnityEngine.UI.Button veryHigh;
    public UnityEngine.UI.Button sublime;
    // Use this for initialization
    void Start()
    {
        this.InitInputSmartPhone();
        this.InitQuality();
    }

    public void InitInputSmartPhone()
    {
        if (PlayerPrefs.GetString(PlayerPrefsString.INPUT_SMARTPHONE) == PlayerPrefsString.TRUE)
        {
            inputSmartPhoneYes.interactable = false;
            inputSmartPhoneNo.interactable = true;
        }
        else
        {
            inputSmartPhoneYes.interactable = true;
            inputSmartPhoneNo.interactable = false;
        }
    }

    public void InitQuality()
    {
        int quality = QualitySettings.GetQualityLevel();
        Debug.Log("quality " + quality);

        PlayerPrefs.SetString(PlayerPrefsString.QUALITY_SETTINGS, quality.ToString());
        this.SetQualityActiveButton(quality);

    }

    private void SetQualityActiveButton(int quality)
    {
    
        this.veryLow.interactable = true;
        this.Low.interactable = true;
        this.Medium.interactable = true;
        this.high.interactable = true;
        this.veryHigh.interactable = true;
        this.sublime.interactable = true;
        switch (quality)
        {
            case 0:
                this.veryLow.interactable = false;
                break;
            case 1 :
                this.Low.interactable = false;
                break;
            case 2:
                this.Medium.interactable = false;
                break;
            case 3:
                this.high.interactable = false;
                break;
            case 4:
                this.veryHigh.interactable = false;
                break;
            case 5:
                this.sublime.interactable = false;
                break;

        }
    }

    public void InputSmartPhoneYesClick()
    {
        PlayerPrefs.SetString(PlayerPrefsString.INPUT_SMARTPHONE, PlayerPrefsString.TRUE);
        this.InitInputSmartPhone();
    }

    public void InputSmartPhoneNoClick()
    {
        PlayerPrefs.SetString(PlayerPrefsString.INPUT_SMARTPHONE, PlayerPrefsString.FALSE);
        this.InitInputSmartPhone();
    }

    public void SetQuality(int quality)
    {
        QualitySettings.SetQualityLevel(quality,true);
        PlayerPrefs.SetString(PlayerPrefsString.QUALITY_SETTINGS, quality.ToString());
        this.SetQualityActiveButton(quality);
    }
    // Update is called once per frame

}
