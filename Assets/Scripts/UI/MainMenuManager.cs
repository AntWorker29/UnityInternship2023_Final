using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    #region FIELDS
    [SerializeField] private Button startButton;
    [SerializeField] private Button quitButton;
    #endregion

    #region SUBSCRIPTIONS
    private void Awake()
    {
        Time.timeScale = 1f;
    }
    #endregion

    #region METHODS
    public void StartGame()
    {
        Loader.LoadScene(Loader.Scene.Gameplay);
    }
    public void ExitGame()
    {
        Application.Quit();
    }
    #endregion
}
