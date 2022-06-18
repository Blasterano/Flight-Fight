using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Credits : MonoBehaviour
{
    public RectTransform credits;
    public GameObject[] names; 

    bool play = false;
    float text_pos, pre_text_pos;
    private void Start()
    {
        text_pos = credits.anchoredPosition.y;
        pre_text_pos = 1800;
    }

    private void Update()
    {
        if (play && text_pos <= pre_text_pos)
        {
            StartCoroutine(Scroll2());
        }
        else if(text_pos>=pre_text_pos)
            SceneManager.LoadScene("Main Menu");

    }
    public void PlayEvent()
    {
        play = true;
        foreach (var obj in names)
            obj.SetActive(false);
    }
    void ScreenPlay()
    {
        for(int i=0;i<5;i++)
        {
            StartCoroutine(Scroll());
        }
    }
    IEnumerator Scroll2()
    {
        ScreenPlay();
        yield return new WaitForSeconds(1f);
    }
    
    IEnumerator Scroll()
    {
        credits.anchoredPosition += new Vector2(0, 0.1f);
        text_pos = credits.anchoredPosition.y;
        yield return null;
    }
}
