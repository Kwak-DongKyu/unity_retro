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
            Vector3.MoveTowards(transform.position, target, 0.1f); //MoveToward(������ġ, ��ǥ��ġ, �ӵ�)
        */
        /*
        Vector3 velo = Vector3.zero;
        transform.position = //SmoothDamp(������ġ, ��ǥ��ġ, �����ӵ�, �ӵ�(�ݺ��))
            Vector3.SmoothDamp(transform.position, target, ref velo, 0.1f);
        
        transform.position = //lerp�� smoothdamp�� ����ϳ� ���������̴�. 
            Vector3.Lerp(transform.position, target, 0.05f);

        */ 
        transform.position = Vector3.Slerp(transform.position, target, 0.01f); //Slerp(���� ����)
     }
}
