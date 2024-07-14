using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MainMenu : MonoBehaviour
{
    
    public GameObject mainMenu;
    public GameObject characterSetting;
    
    public void PlayInMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void Character()
    {
        mainMenu.SetActive(false);
        characterSetting.SetActive(true);
    }
    public void Exit()
    {
        mainMenu.SetActive(true);
        characterSetting.SetActive(false);
    }
    
}
