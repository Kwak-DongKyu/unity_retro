using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gunaim : MonoBehaviour
{
    public Camera followcam;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gunaiming();
    }
    void gunaiming() //���콺 ��ġ�� ���� �ٶ󺸰� �ϴ� �Լ�
    {
        Ray ray = followcam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if(Physics.Raycast(ray, out hit))
        {
            Vector3 nextVec = hit.point - transform.position;
            transform.LookAt(transform.position + nextVec);
        }

    }
}
