using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class target : MonoBehaviour, Idamageable
{
    public void Ondamage(Vector3 hitPoint, Vector3 hitNormal)
    {
        gamemanager.instance.score++;

        Invoke("whencollision", 0.5f);
    }
    private void whencollision()
    {
        gameObject.SetActive(false);
    }
}
