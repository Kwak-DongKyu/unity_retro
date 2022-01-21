using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class gamemanager : MonoBehaviour
{
    public static gamemanager instance;
    public int remainammo = 5;
    public int score = 0;
    public int totalscore = 3;

    public Text scorenow;
    public Text remain;
    public GameObject gameclear;

    private void Awake()
    {
        if(instance == null){
            instance = this;
        }
        else
        {
            Debug.LogWarning("씬에 두 개 이상의 게임 매니저가 존재함");
            Destroy(gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        scorenow.text = score.ToString();
        remain.text = remainammo + " / 5";
        if(totalscore == score)
        {
            Cursor.visible = true;

            gameclear.SetActive(true);
        }
    }
    public void restarting()
    {
        SceneManager.LoadScene(0);
    }
}
