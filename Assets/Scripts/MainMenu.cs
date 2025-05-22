using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject instructionsPanel;
    public GameObject settingsPanel;
    public GameObject mainMenuButtons;
    // Start is called before the first frame update
    void Start()
    {
        instructionsPanel.SetActive(false);
        settingsPanel.SetActive(false);
        mainMenuButtons.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        SceneManager.LoadScene("movement");
    }

    public void Settings()
    {
        settingsPanel.SetActive(true);
        mainMenuButtons.SetActive(false);
    }
        
    public void Instructions()
    {
        instructionsPanel.SetActive(true);
        mainMenuButtons.SetActive(false);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void BackButton()
    {
        instructionsPanel.SetActive(false);
        settingsPanel.SetActive(false);
        mainMenuButtons.SetActive(true);
    }
}
