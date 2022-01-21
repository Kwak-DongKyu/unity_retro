using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRigidbody;
    public float speed = 8f;
    public GameManager manager;

    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        float xInput = Input.GetAxis("Horizontal");
        float zInput = Input.GetAxis("Vertical");

        Vector3 vec = new Vector3(xInput * speed, 0, zInput * speed);
        playerRigidbody.velocity = vec;
    }

    public void Die()
    {
        manager.EndGame();
        gameObject.SetActive(false);
    }
}
