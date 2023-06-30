using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class Loader
{
    #region FIELDS
    public enum Scene
    {
        MainMenuScene,
        LoadingScene,
        Gameplay
    }
    private static Scene targetScene;
    #endregion

    #region METHODS
    public static void LoadScene(Scene sceneToLoad)
    {
        Loader.targetScene = sceneToLoad;
        SceneManager.LoadScene(Scene.LoadingScene.ToString());
    }
    public static void LoaderCallback()
    {
        SceneManager.LoadScene(targetScene.ToString());
    }
    #endregion
}
