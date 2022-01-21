using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class targetmovement : MonoBehaviour
{
    Rigidbody rigid;
    public int speed = 10;
    int a = 1;
    public int movingmax=7;
    public int b = 1;
    

    private void Awake()
    {
        rigid = GetComponent<Rigidbody>();
    }
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per fram    private void reciprocation() //물체 왕복운동하게 하는 함수
    private void Update()
    {
        if (transform.position.x < -movingmax)
        {
            a = 1;
        }
        else if (transform.position.x > movingmax)
        {
            a = -1;
        }
        transform.Translate(Vector3.right * Time.deltaTime * a * speed, Space.World);
    }
        
    
}
