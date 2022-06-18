using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    GameObject[] rings;
    PlayerScore playerScore;
    SceneLoader sceneLoader;
    AudioSource audioSource;

    public TMP_Text ringsLeft1, ringsLeft2, score1, score2;
    public TMP_Text player1, player2;
    public GameObject score;
    public AudioClip start, finish;
    public int playerScore1, playerScore2;

    // Start is called before the first frame update
    void Start()
    {
        playerScore1 = playerScore2 = 0;

        playerScore = FindObjectOfType<PlayerScore>();
        sceneLoader = FindObjectOfType<SceneLoader>();
        audioSource= GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        rings = GameObject.FindGameObjectsWithTag("Ring");
        ringsLeft1.text = "Rings left : " + rings.Length;
        ringsLeft2.text = "Rings left : " + rings.Length;
        score1.text = "score : " + playerScore1;
        score2.text = "score : " + playerScore2;

        if (playerScore.finished)
        {
            audioSource.PlayOneShot(finish);
            score.SetActive(true);
            player1.text = "Player 1 : " + playerScore1;
            player2.text = "Player 2 : " + playerScore2;
            StartCoroutine("Timer");
        }

    }

    /*public void Finish()
    {
        if (rings.Length != 0)
        {
            playerController.finished = false;
        }
        else
        {
            playerController.finished = true;
            score.SetActive(true);
            Debug.Log("next scene");
        }
    }*/

    public bool FinishPoint()
    {
        if (rings.Length != 0)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    IEnumerator Timer()
    {
        yield return new WaitForSeconds(5.0f);
        sceneLoader.NextScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
