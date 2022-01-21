using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class gamemanagerlogic : MonoBehaviour
{
    public int totalscore;
    public int stage;
    public Text stageCountText;
    public Text PlayerCountText;

    private void Awake()
    {
        stageCountText.text = "/" + totalscore; 
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            SceneManager.LoadScene("Level" + stage.ToString());
        }
            
    }
    public void GetItem(int count)
    {
        PlayerCountText.text = count.ToString();
    }
}
