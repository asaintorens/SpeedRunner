using UnityEngine;
using System.Collections;
using System;
using Assets.MyAssets.Resources.Script;

public class MenuUiOptions : MonoBehaviour
{


    public MenuController menu;

    public UnityEngine.UI.Button inputSmartPhoneYes;
    public UnityEngine.UI.Button inputSmartPhoneNo;


    // Use this for initialization
    void Start()
    {
        this.InitInputSmartPhone();
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
    // Update is called once per frame

}
