using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScore : MonoBehaviour
{
    public bool finished=false;

    GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager=FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player") && this.gameObject.CompareTag("Ring"))
        {
            Debug.Log(other.name);
            gameManager.playerScore1++;
        }
        else if (other.gameObject.CompareTag("Player 2") && this.gameObject.CompareTag("Ring"))
        {
            Debug.Log(other.name);
            gameManager.playerScore2++;
        }

        if (this.gameObject.CompareTag("Finish") && other.gameObject.CompareTag("Player") && gameManager.FinishPoint())
        {
            gameManager.playerScore1 += 5;
            Destroy(other.gameObject);
            finished = true;
            Destroy(this.gameObject);
        }
        else if (this.gameObject.CompareTag("Finish") && other.gameObject.CompareTag("Player 2") && gameManager.FinishPoint())
        {
            gameManager.playerScore2 += 5;
            Destroy(other.gameObject);
            finished = true;
            Destroy(this.gameObject);
        }
        else
            finished = false;
    }
}
