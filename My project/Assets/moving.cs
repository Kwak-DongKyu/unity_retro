using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moving : MonoBehaviour
{
    Vector3 target = new Vector3(38, 10, -18);
    // Update is called once per frame
    void Update()
    {
        /*
        Vector3 vec = new Vector3(0.1f * Input.GetAxis("Horizontal"), 0.1f * Input.GetAxis("Vertical"), 0);
        transform.Translate(vec);
        */



        /*
        transform.position =
            Vector3.MoveTowards(transform.position, target, 0.1f); //MoveToward(현재위치, 목표위치, 속도)
        */
        /*
        Vector3 velo = Vector3.zero;
        transform.position = //SmoothDamp(현재위치, 목표위치, 참조속도, 속도(반비례))
            Vector3.SmoothDamp(transform.position, target, ref velo, 0.1f);
        
        transform.position = //lerp는 smoothdamp와 비슷하나 선형보간이다. 
            Vector3.Lerp(transform.position, target, 0.05f);

        */ 
        transform.position = Vector3.Slerp(transform.position, target, 0.01f); //Slerp(구면 선형)
     }
}
