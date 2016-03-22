using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

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
