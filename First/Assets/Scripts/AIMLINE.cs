using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIMLINE : MonoBehaviour
{
    private LineRenderer aimline;
    public Transform fireposition;
    public Camera followcam;

    // Start is called before the first frame update
    void Start()
    {
        aimline = GetComponent<LineRenderer>();
        aimline.positionCount = 2;
    }

    // Update is called once per frame
    void Update()
    {
        Cursor.visible = false;
        Ray ray = followcam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        Physics.Raycast(ray, out hit);
        

        aimline.SetPosition(0, fireposition.position);
        aimline.SetPosition(1, hit.point) ;
        aimline.enabled = true;
    }
    
}
