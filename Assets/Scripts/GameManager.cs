using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    PlayerScore playerScore;
    SceneLoader sceneLoader;
    AudioSource audioSource;

    int player1Win = 0, player2Win = 0;

    public TMP_Text ringsLeft1, ringsLeft2, score1, score2;
    public TMP_Text total1, total2;
    public TMP_Text playerWinText;
    public GameObject gameWinPanel;
    public GameObject score;
    public AudioClip start, finish;
    public int playerScore1, playerScore2;
    public int ringCount;

    // Start is called before the first frame update
    void Start()
    {
        ringCount = GameObject.FindGameObjectsWithTag("Ring").Length;
        
        playerScore1 = playerScore2 = 0;

        playerScore = FindObjectOfType<PlayerScore>();
        sceneLoader = FindObjectOfType<SceneLoader>();
        audioSource= GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        ringsLeft1.text = "Rings left : " + ringCount;
        ringsLeft2.text = "Rings left : " + ringCount;
        score1.text = "score : " + playerScore1;
        score2.text = "score : " + playerScore2;
        //Debug.Log(player1Win + "--" + player2Win);
        if (playerScore.finished)
        {
            audioSource.PlayOneShot(finish);
            score.SetActive(true);
            total1.text = "Player 1 : " + playerScore1;
            total2.text = "Player 2 : " + playerScore2;

            if (playerScore1 > playerScore2)
                player1Win++;
            else if (playerScore1 < playerScore2)
                player2Win++;
            
            StartCoroutine("Timer");
        }

    }

    public bool FinishPoint()
    {
        if (ringCount != 0)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    private void LevelWinUI()
    {
        
            score.SetActive(false);
            gameWinPanel.SetActive(true);
            audioSource.PlayOneShot(finish);

            if (player1Win > player2Win)
                playerWinText.text = "Player 1 Won";
            else if (player1Win < player2Win)
                playerWinText.text = "Player 2 Won";
            else
                playerWinText.text = "DRAW";
        
    }

    IEnumerator Timer()
    {
        //-2 because scene index starts from 0
        if (SceneManager.sceneCountInBuildSettings-2 == SceneManager.GetActiveScene().buildIndex)
        {
            yield return new WaitForSeconds(3.0f);
            LevelWinUI();
        }

        yield return new WaitForSeconds(5.0f);
        sceneLoader.NextScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
