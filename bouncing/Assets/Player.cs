using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public int jumppower;
    bool isjump;
    Rigidbody rigid;
    AudioSource audio;
    public int itemcounts;
    public gamemanagerlogic manager;

      
    void Awake()
    {
        rigid = GetComponent<Rigidbody>();
        isjump = false;
        audio = GetComponent<AudioSource>();
        
    }

    private void Update()
    {
        if(Input.GetButtonDown("Jump") && !isjump)
        {
            isjump = true;
            rigid.AddForce(new Vector3(0, jumppower, 0), ForceMode.Impulse);
        }
        
    }
    void FixedUpdate()
    {
        float f = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        Vector3 vec = new Vector3(-f*0.2f, 0, -v*0.2f);
        rigid.AddForce(vec, ForceMode.Impulse);
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "ground")
        {
            isjump= false;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "item")
        {
            audio.Play();
            itemcounts++;
            other.gameObject.SetActive(false);
            manager.GetItem(itemcounts);

        }
        
        else if(other.gameObject.tag == "finish")
        {
            if(itemcounts == manager.totalscore)
            {
                if(manager.stage == 3)
                {
                    SceneManager.LoadScene(0);
                }
                SceneManager.LoadScene(manager.stage);
            }
            else
            {
                SceneManager.LoadScene(manager.stage - 1);

            }
        }
        
    }
}
