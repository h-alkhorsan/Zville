using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoadController : MonoBehaviour
{
    private string sceneName;
    private string currentScene;

    // Load first map scene, persistent scene is already loaded
    void Start()
    {
        LoadHouseScene("Interior");
    }

    // Set callback for loading new map scene, start unloading
    public void LoadNewHouseScene(string sceneName)
    {
        SceneManager.sceneUnloaded += HouseSceneUnloadFinished;
        this.sceneName = sceneName;
        SceneManager.UnloadSceneAsync("SampleScene");
    }

    // Remove callback, call load for new map scene
    private void HouseSceneUnloadFinished(Scene unloadedScene)
    {
        SceneManager.sceneUnloaded -= HouseSceneUnloadFinished;
        if (!SceneManager.GetSceneByName(sceneName).isLoaded)
        {
            LoadHouseScene(sceneName);
        }
    }

    // Set currentSceneName, load a map scene in additive mode to keep persistent scene
    private void LoadHouseScene(string sceneName)
    {
        currentScene = sceneName;
        SceneManager.LoadScene(sceneName, LoadSceneMode.Additive);
    }
}

