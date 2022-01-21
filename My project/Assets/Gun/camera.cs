using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera : MonoBehaviour
{
    public GameManagerLogic GM;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(GM.score == 1)
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(10, 6, 0), 1f);

        }
        if(GM.score == 2)
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(10, 8, 0), 1f);
        }
    }
}
