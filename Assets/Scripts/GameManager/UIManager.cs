using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public GameObject optionsMenu;
    public GameObject musicSelection;
    public GameObject mainMenu;

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		
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
}
