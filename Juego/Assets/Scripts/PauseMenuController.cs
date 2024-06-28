using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuController : MonoBehaviour
{
    [SerializeField] private GameObject PauseButton;
    [SerializeField] private GameObject PauseMenu;
    private bool PauseGame = false;

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(PauseGame)
            {
                resume();
            }
            else
            {
                pause();
            }
        }
    }
    public void pause()
    {
       PauseGame = true;
       Time.timeScale = 0f;
       PauseButton.SetActive(false);
       PauseMenu.SetActive(true);
    }

    public void resume()
    {
        PauseGame = false;
        Time.timeScale = 1f;
        PauseButton.SetActive(true);
        PauseMenu.SetActive(false);
    }
    public void Reset()
    {
        PauseGame = false;
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Quit()
    {
        Debug.Log("Coming out");
        Application.Quit();
    }
}
