using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class otherball : MonoBehaviour
{
    MeshRenderer mesh;
    Material mat;

    void Start()
    {
        mesh = GetComponent<MeshRenderer>();
        mat = mesh.material;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "My Ball")
        {
            mat.color = new Color(0, 0, 0);
        }
       
    }
    
}
