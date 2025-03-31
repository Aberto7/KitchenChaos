using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class Loader {


    public enum Scene{
        MainMenuScene,
        GameScene,
        LoadingScene
    }
    
    
    private static Scene targertScene;


    public static void Load(Scene targertScene) {
        Loader.targertScene = targertScene;

        SceneManager.LoadScene(Scene.LoadingScene.ToString());
    }

    public static void LoaderCallback(){
        SceneManager.LoadScene(targertScene.ToString());
    }


}