using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndScreennav : MonoBehaviour
{
    public string SceneName;

    public void Restart()
    {
        SceneManager.LoadScene(SceneName);
        Time.timeScale = 1f;
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
