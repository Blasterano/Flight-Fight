using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Intro : MonoBehaviour
{
    private void Update()
    {
        if(Time.time>7)
        {
            SceneManager.LoadScene(1);
        }
    }
}
