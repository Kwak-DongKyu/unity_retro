using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lifecycle : MonoBehaviour
{
    
    void Update()
    {
        if (Input.anyKeyDown) //Input�� �Է��� ����, anykeyDown �ƹ�Ű�� �Է�
            Debug.Log("�÷��̾ �ƹ� Ű�� �������ϴ�.");
        /*
        if (Input.GetKeyDown(KeyCode.Return)) //return�� ���� Ű�� �ǹ��Ѵ�., escape�� escŰ�� �ǹ�
            Debug.Log("�������� �����Ͽ����ϴ�.");
        if (Input.GetKey(KeyCode.LeftArrow))
            Debug.Log("�������� �̵� ��");
        if (Input.GetKeyUp(KeyCode.RightArrow))
            Debug.Log("������ �̵��� ���߾����ϴ�.");
        
        if (Input.GetMouseButtonDown(0)) //0�� ���콺 ����, 1�� ���콺 ������ ��ư
            Debug.Log("�̻��� �߻�!");
        if (Input.GetButtonDown("Jump"))
            Debug.Log("����");

        //if (Input.anyKey) //anyKey ������ ������ �ν�, anyKeyUp(Ű�� ������ ���� ��)
        //  Debug.Log("�÷��̾ �ƹ� Ű�� ������ �ֽ��ϴ�.")*/
        if (Input.GetButton("Horizontal"))
        {
            Debug.Log("Ⱦ �޿� ��..." + Input.GetAxisRaw("Horizontal")); //Horizonal �� ���� ��ȯ
            //GetAxis�� ��� ����ġ, GetAxisRaw�� ��� -1�� ����ϰ�
        }
        Vector3 vec = new Vector3(0, 0.1f, 0);
        transform.Translate(vec);
    }
} 
