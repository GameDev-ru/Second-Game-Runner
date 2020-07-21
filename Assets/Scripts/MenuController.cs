using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public GameObject buttonsMenu;
    public GameObject buttonsExit;
    public GameObject buttonsOptions;


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
        buttonsMenu.SetActive(false);
        buttonsExit.SetActive(false);
        buttonsOptions.SetActive(false);
      
    }
    public void Exit()
    {
        Application.Quit();
    }
//public void ()
//    {

//    }
//        public void ()
//    {

//    }
//        public void ()
//    {

//    }
//        public void ()
//    {

//    }
//        public void ()
//    {

//    }













}
