using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    int level = 15;
    void Start()
    {
        Debug.Log("Hello Unity");

        int level = 5;
        float strength = 15.5f;
        string playerName = "���˻�";
        bool isFullLevel = false;

        string[] monsters = { "������", "�縷��", "�Ǹ�" };
        List<string> items = new List<string>();
        items.Add("������");
        items.Add("potion");
        Debug.Log(items[1]);

        int exp = 1500;
        exp = exp + 320;
        level = exp / 300;
        strength = level * 3.1f;
        Debug.Log(strength);
        int health = 30;
        int mana = 25;
        bool isBadcondition = health < 50 || mana < 25;
        Debug.Log("���°� ����ϱ�"+isBadcondition);
        string condition = isBadcondition ? "����" : "����";
        Debug.Log("���� ����� ���´� " + condition);
        string[] monster = { "������", "�Ǹ�", "��" };
        int[] monsterlevel = { 10, 20, 30 };
        switch (monster[0])
        {
            case "������":
                Debug.Log("���� ���� ����");
                break;
            case "�Ǹ�":
                Debug.Log("���� ���� ����");
                break;
            default:
                Debug.Log("?? ���� ����");
                break;
        }
        foreach(string a in monster)
        {
            Debug.Log("�� ���� ����" + a);
        }
        for (int index =0; index < monsterlevel.Length; index++){
            Debug.Log("����" + monster[index] + "�� �ο���" + Battle(monsterlevel[index]));
        }

        parent pa = new parent();
        pa.id = 10;
        Debug.Log(pa.id);
        baby ba = new baby();
        ba.id = 20;
        Debug.Log(ba.id + ba.move());

    }
    string Battle(int mlevel)
    {
        string result;
        if (level > mlevel)
            result = "�̰���ϴ�";
        else
            result = "�����ϴ�";
        return result;

    }

}
