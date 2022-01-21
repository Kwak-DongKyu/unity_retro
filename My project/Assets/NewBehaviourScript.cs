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
        string playerName = "나검사";
        bool isFullLevel = false;

        string[] monsters = { "슬라임", "사막뱀", "악마" };
        List<string> items = new List<string>();
        items.Add("생명물약");
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
        Debug.Log("상태가 어떻습니까"+isBadcondition);
        string condition = isBadcondition ? "나쁨" : "좋음";
        Debug.Log("현재 용사의 상태는 " + condition);
        string[] monster = { "슬라임", "악마", "골렘" };
        int[] monsterlevel = { 10, 20, 30 };
        switch (monster[0])
        {
            case "슬라임":
                Debug.Log("소형 몬스터 출현");
                break;
            case "악마":
                Debug.Log("중형 몬스터 출현");
                break;
            default:
                Debug.Log("?? 몬스터 출현");
                break;
        }
        foreach(string a in monster)
        {
            Debug.Log("이 지역 몬스터" + a);
        }
        for (int index =0; index < monsterlevel.Length; index++){
            Debug.Log("용사는" + monster[index] + "와 싸워서" + Battle(monsterlevel[index]));
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
            result = "이겼습니다";
        else
            result = "졌습니다";
        return result;

    }

}
