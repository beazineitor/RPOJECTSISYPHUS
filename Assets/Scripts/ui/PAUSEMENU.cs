using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PAUSEMENU : MonoBehaviour
{
    public static bool gameIsPause = false;
    public GameObject pauseMenuiUI;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (gameIsPause)
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
        pauseMenuiUI.SetActive(false);
        Time.timeScale = 1F;
        gameIsPause = false;
      
    }
    void Pause()
    {
        pauseMenuiUI.SetActive(true);
        Time.timeScale = 0f;
        gameIsPause = true;
        print("isPuased");
       
    }
    public void loadMenu()
    {
        Time.timeScale = 1F;
        SceneManager.LoadScene("MENU");
    }
    public void quitGame()
    {
        Debug.Log("quitinggame");
        Application.Quit();
    }
}
