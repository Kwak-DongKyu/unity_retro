using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gunfiring : MonoBehaviour
{
    Rigidbody rigid;
    public int gunspeed = 10;

    private void Start()
    {
        Debug.Log(transform.position.z);

        rigid = GetComponent<Rigidbody>();
        rigid.velocity = transform.up * gunspeed * Time.deltaTime;
       
        
        //rigid.velocity =  * gunspeed * Time.deltaTime;

        Destroy(gameObject, 6);
    }
    

}
