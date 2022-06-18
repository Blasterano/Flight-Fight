using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class gamecontroller : MonoBehaviour
{
    public static gamecontroller instance;
    public GameObject credits, cname;
    public Text message;
    string sentence;
    public float speed = -1.5f;
    float timer ;
    
    // Start is called before the first frame update
    private void Start()
    {
        sentence = message.text;
        timer = 0;
    }
    void Awake()
    {
        if(instance==null)
        {
            instance = this;
        }
        else if(instance!=this)
        {
            Destroy(gameObject);
        }
    }
    
    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer<2)
        {
            message.gameObject.SetActive(true);
            StartCoroutine(read(sentence));
        }
        else if(timer>2&&timer<5)
        {
            StopAllCoroutines();
            message.gameObject.SetActive(false);
            cname.SetActive(true);
            credits.SetActive(true);
        }
    }
    IEnumerator read(string msg)
    {
        message.text = "";
        foreach(char l in msg.ToCharArray())
        {
            message.text += l;
            yield return null;
        }
    }
    
}
