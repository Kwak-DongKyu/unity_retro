using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class My_Ball : MonoBehaviour
{
    Rigidbody rigid;
    void Start()
    {
        rigid = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        float j = Input.GetAxisRaw("Jump");
        Vector3 vec = new Vector3(h*0.1f, j, v*0.1f);

        rigid.AddForce(vec, ForceMode.Impulse);
        
    }
    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.name == "Cube")
        {
            rigid.AddForce(Vector3.up, ForceMode.Impulse);
        }
    }
    public void Jump()
    {
        rigid.AddForce(Vector3.up * 20, ForceMode.Impulse);
    }
}
