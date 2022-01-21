using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class targetmovement2 : MonoBehaviour
{
    Rigidbody rigid;
    public int speed = 10;
    int a = 1;
    public int movingmax = 7;


    private void Awake()
    {
        rigid = GetComponent<Rigidbody>();
    }
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        reciprocation();

    }
    private void reciprocation() //물체 왕복운동하게 하는 함수
    {
        if (transform.position.x < -movingmax)
        {
            a = -1;
        }
        else if (transform.position.x > movingmax)
        {
            a = 1;
        }
        transform.Translate(Vector3.left * Time.deltaTime * a * speed, Space.World);
    }
}
