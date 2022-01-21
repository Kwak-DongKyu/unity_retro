using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManagerLogic : MonoBehaviour
{
    public int stage;
    public int score;
    public int totalscore;
    public Text stageCountText;
    public Text PlayerCountText;

    // Start is called before the first frame update
    void Awake()
    {
        stageCountText.text = "/ " + totalscore;
    }

    // Update is called once per frame
    void Update()
    {
        PlayerCountText.text = score.ToString();
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            SceneManager.LoadScene(stage);
        }
    }

}
