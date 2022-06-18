using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool ispaused;
    public GameObject pauseUI;

    private AudioPlayer audioPlayer;

    private void Start()
    {
        audioPlayer = FindObjectOfType<AudioPlayer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (ispaused)
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
        audioPlayer.PlayClip();
        pauseUI.SetActive(false);
        Time.timeScale = 1f;
        ispaused = false;
    }
    void Pause()
    {
        audioPlayer.PlayClip();
        pauseUI.SetActive(true);
        Time.timeScale = 0f;
        ispaused = true;
    }
    public void menu()
    {
        audioPlayer.PlayClip();
        Time.timeScale = 1f;
    }

}
