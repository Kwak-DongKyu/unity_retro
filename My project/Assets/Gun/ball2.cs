using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ball2 : MonoBehaviour
{
    Rigidbody rigid;
    public ball3 ball_3;
    public GameManagerLogic GM;
    bool isadd = true;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);
        rigid = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && isadd)
        {
            isadd = false;
            rigid.AddForce(Vector3.left * 10, ForceMode.Impulse);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        
        if (collision.gameObject.tag == "objects")
        {
            gameObject.SetActive(false);
            ball_3.gameObject.SetActive(true);
            GM.score++;
        }
    }
}
