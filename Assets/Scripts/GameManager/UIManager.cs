using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public GameObject optionsMenu;
    public GameObject musicSelection;
    public GameObject mainMenu;
    public GameObject pauseMenu;
    public GameObject inGameUI;
    public GameObject pauseOptions;
    public GameObject deadMenu;

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    

    public void ActivateDeadMenu()
    {
        inGameUI.SetActive(false);
        deadMenu.SetActive(true);
    }

    public void OnClickedButtonRestart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1f;
    }

    public void OnClickedButtonPause()
    {
        GameObject.FindGameObjectWithTag("Music").GetComponent<AudioSource>().Pause();
        inGameUI.SetActive(false);
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
    }

    public void OnClickedButtonPauseResume()
    {
        inGameUI.SetActive(true);
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        GameObject.FindGameObjectWithTag("Music").GetComponent<AudioSource>().UnPause();
    }

    public void OnClickedButtonPauseOptions()
    {
        pauseMenu.SetActive(false);
        pauseOptions.SetActive(true);
    }

    public void OnClickedButtonPauseOptionsBack()
    {
        pauseMenu.SetActive(true);
        pauseOptions.SetActive(false);
    }

    public void OnClickedButtonPlay()
    {
        SceneManager.LoadScene("TheoTestScene");
    }

    public void OnClickedButtonPlayMusicSelection()
    {
        musicSelection.SetActive(true);
        mainMenu.SetActive(false);
    }

    public void OnClickedButtonPlayBack()
    {
        musicSelection.SetActive(false);
        mainMenu.SetActive(true);
    }

    public void OnClickedButtonQuit()
    {
        Application.Quit();
    }

    public void OnClickedButtonShop()
    {
        SceneManager.LoadScene("ShopScene");
    }

    public void OnClickedButtonOption()
    {
        optionsMenu.SetActive(true);
        mainMenu.SetActive(false);
    }

    public void OnClickedButtonOptionBack()
    {
        optionsMenu.SetActive(false);
        mainMenu.SetActive(true);
    }

    public void OnClickedButtonShopPauseBack()
    {
        SceneManager.LoadScene("Main_Menu");
        Time.timeScale = 1f;
    }
}
