using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class gamemanager : MonoBehaviour
{
    public int totalPoint;
    public int stagePoint;
    public int stageIndex;
    public int health;
    public Player player;
    public GameObject[] Stages;

    public Image[] UIhealth;
    public Text UIPoint;
    public Text UIStage;
    public GameObject UIRestartBtn;
    public GameObject UIEndingBtn;
    public Text Endingcredit;

    private void Update()
    {
        UIPoint.text = (totalPoint + stagePoint).ToString();
    }
    public void NextStage()
    {
        //change stage
        if(stageIndex < Stages.Length -1)
        {
            Stages[stageIndex].SetActive(false);
            stageIndex++;
            Stages[stageIndex].SetActive(true);
            PlayerReposition();
            UIStage.text = "Stage" + (stageIndex + 1);
        }
        else //game clear
        {
            //Player control lock
            Time.timeScale = 0;
            
            //restart button UI
            Text btnText = UIRestartBtn.GetComponentInChildren<Text>(); //text가 버튼 안에 있으므로
            btnText.text = "게임 클리어(다시시작)";
            ViewBtn();
            
            Endingcredit.text = "당신의 최종점수는 " + (totalPoint+stagePoint).ToString() + "입니다"; 
        }

        //caculate point
        totalPoint += stagePoint;
        stagePoint = 0;

    }

    public void HealthDown()
    {
        if (health > 1)
        {
            stagePoint -= 100;
            health--;
            UIhealth[health].color = new Color(1, 0, 0, 0.4f);
        }
        else
        {

            //all health UI off
            UIhealth[0].color = new Color(1, 0, 0, 0.4f);
            //player Die Effect
            player.Ondie();

            //Retry Button UI
            UIRestartBtn.SetActive(true);

        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {       

            //player reposition
            if(health > 1)
            {
                PlayerReposition();
            }
            //health down
            HealthDown();
        }
    }

    void PlayerReposition()
    {
        player.transform.position = new Vector3(-5, 4, 0);
        player.VelocityZero();
    }
    void ViewBtn()
    {
        UIRestartBtn.SetActive(true);
        UIEndingBtn.SetActive(true);
    }
    public void Restart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }
    public void endinggame()
    {
        Application.Quit();
    }
}
