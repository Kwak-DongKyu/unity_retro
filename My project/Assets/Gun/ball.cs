using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ball : MonoBehaviour
{
    Rigidbody rigid;
    public GameManagerLogic GM;
    public ball2 ball_2;
    bool isadd;
    // Start is called before the first frame update
    void Start()
    {
        isadd = true;
        rigid = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetMouseButtonDown(0) && isadd)
        {
            isadd = false;
            rigid.AddForce(Vector3.left*10, ForceMode.Impulse);
        }
    }
   
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "objects" )
        {
            GM.score++;
            gameObject.SetActive(false);

            if (GM.stage == 1 && (GM.totalscore == GM.score))
            {
                collision.gameObject.SetActive(false);
                SceneManager.LoadScene(2);
            }
            else
            {
                ball_2.gameObject.SetActive(true);
            }

            
            
        }
    }
    
}
