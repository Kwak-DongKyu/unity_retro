using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class targetentity : MonoBehaviour, Idamageable
{
 
    public virtual void Ondamage(Vector3 hitPoint, Vector3 hitNormal)
    {
        Debug.Log("���� ��ġ�� " + hitPoint);
    }
}
