using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO;

public class Menu : MonoBehaviour
{


    public GameObject buttonsMenu;
    public GameObject buttonsOptions;
    public GameObject buttonsExit;
    public Slider slider;
    public GameObject pauseMenuUi;
    public GameObject coins;
    public static bool GameisPause = false;
    public float volume;
    Scene scene;

    private void Start()
    {
        LoadAudio();
    }


    private void Awake()
    {
        scene = SceneManager.GetActiveScene();

    }
    void Update()
    {
        Volume();
        PauseGame();
    }

    public void PauseGame()
    {
        if (scene.name == "Menu" && Input.GetKeyDown(KeyCode.Escape))
        {
            BackInMenu();
        }

        if (scene.name == "Scene" && Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameisPause)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        pauseMenuUi.SetActive(false);
        coins.SetActive(true);
        Time.timeScale = 1f;
        GameisPause = false;
        SaveLoad.SaveGame(volume);
        
    }

    public void Volume()
    {
        AudioListener.volume = slider.value;
         volume = slider.value;
      
    }
    
    void Pause()
    {
        pauseMenuUi.SetActive(true);
        coins.SetActive(false);
        Time.timeScale = 0f;
        GameisPause = true;
    }

    public void ShowExitButtons()
    {
        buttonsMenu.SetActive(false);
        buttonsExit.SetActive(true);
        buttonsOptions.SetActive(false);

    }

    public void BackInMenu()
    {
        buttonsMenu.SetActive(true);
        buttonsExit.SetActive(false);
        buttonsOptions.SetActive(false);
        SaveLoad.SaveGame(volume);
    }

    public void ShowPauseButtons()
    {

    }

    public void ShowOptionsButtons()
    {
        buttonsMenu.SetActive(false);
        buttonsExit.SetActive(false);
        buttonsOptions.SetActive(true);

    }

    public void StartGame()
    {
        
        SceneManager.LoadScene("Scene");
        
    }

    public void LoadMenu()
    {
        SaveLoad.SaveGame(volume);
        SceneManager.LoadScene("Menu");
        Time.timeScale = 1f;
    }

    public void QuitGame()
    {
       
        Application.Quit();
    }

    public void LoadAudio()
    {
        AudioSave data = SaveLoad.LoadGame(); //Получение данных

        if (!data.Equals(null)) //Если данные есть
        {
            AudioListener.volume = data.MenuVolume;
            slider.value = data.MenuVolume;
        }
    }

}
