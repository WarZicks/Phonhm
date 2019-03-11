using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public GameObject optionsMenu;
    public GameObject musicSelection;
    public GameObject mainMenu;
    public GameObject pauseMenu;
    public GameObject inGameUI;
    public GameObject pauseOptions;
    public GameObject deadMenu;
    public GameObject splashScreen;
    public GameObject tuto;

    public GameObject buttonTuto;

    public Sprite tutoDisabled;
    public Sprite tutoEnabled;

    public bool tutoOn = true;

	// Use this for initialization
	void Start ()
    {
        Time.timeScale = 0;
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public void OnClickTuto()
    {
        if (tutoOn == true)
        {
            tutoOn = false;
            buttonTuto.GetComponent<Image>().sprite = tutoDisabled;
        }
        else
        {
            tutoOn = true;
            buttonTuto.GetComponent<Image>().sprite = tutoEnabled;
        }
    }

    public void SplashScreen ()
    {
        mainMenu.SetActive(true);
        splashScreen.SetActive(false);
    }
    
    public void ActivateDeadMenu()
    {
        GameObject.FindGameObjectWithTag("Music").GetComponent<AudioSource>().Stop();
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
        SceneManager.LoadScene("MainScene");
        if (tutoOn == true)
        {
            tuto.SetActive(true);
            inGameUI.SetActive(false);
        }
        else if (tutoOn == false)
        {
            tuto.SetActive(false);
            inGameUI.SetActive(true);
            Time.timeScale = 1;
        }
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

    public void OnSkipTuto()
    {
        Time.timeScale = 1;
        tuto.SetActive(false);
        inGameUI.SetActive(true);
    }
}
