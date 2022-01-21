using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objects : MonoBehaviour
{
    Rigidbody rigid;
    AudioSource audio;
    public int ballspeed;
    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody>();
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    int a = 1;

    void Update()
    {
        
        if (transform.position.z < -4.5f)
        {
            a = 1;
        }

        else if (transform.position.z > 4.5f)
        {
            a = -1;
        }
        transform.Translate(Vector3.forward * ballspeed * Time.deltaTime * a);
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            audio.Play();
        }
    }

}
