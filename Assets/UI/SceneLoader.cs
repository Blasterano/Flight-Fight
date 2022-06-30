using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoader : MonoBehaviour
{
    public GameObject loading_screen;
    public Slider loading;

    
    public void NextScene(int scene_index)
    {
        StartCoroutine(LoadAsynchronously(scene_index));
    }

    IEnumerator LoadAsynchronously(int sceneindex)
    {
        Debug.Log("loading");
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneindex);
        loading_screen.SetActive(true);

        while(!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / 0.9f);
            loading.value = progress;
            yield return null;
        }

    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
