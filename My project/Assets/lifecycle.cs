using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lifecycle : MonoBehaviour
{
    
    void Update()
    {
        if (Input.anyKeyDown) //Input이 입력을 받음, anykeyDown 아무키나 입력
            Debug.Log("플레이어가 아무 키를 눌렀습니다.");
        /*
        if (Input.GetKeyDown(KeyCode.Return)) //return은 엔터 키를 의미한다., escape는 esc키를 의미
            Debug.Log("아이템을 구입하였습니다.");
        if (Input.GetKey(KeyCode.LeftArrow))
            Debug.Log("왼쪽으로 이동 중");
        if (Input.GetKeyUp(KeyCode.RightArrow))
            Debug.Log("오른쪽 이동을 멈추었습니다.");
        
        if (Input.GetMouseButtonDown(0)) //0은 마우스 왼쪽, 1은 마우스 오른쪽 버튼
            Debug.Log("미사일 발사!");
        if (Input.GetButtonDown("Jump"))
            Debug.Log("점프");

        //if (Input.anyKey) //anyKey 누르고 있음을 인식, anyKeyUp(키를 누르고 뗏을 때)
        //  Debug.Log("플레이어가 아무 키를 누르고 있습니다.")*/
        if (Input.GetButton("Horizontal"))
        {
            Debug.Log("횡 읻오 중..." + Input.GetAxisRaw("Horizontal")); //Horizonal 은 값을 반환
            //GetAxis의 경우 가중치, GetAxisRaw의 경우 -1로 깔끔하게
        }
        Vector3 vec = new Vector3(0, 0.1f, 0);
        transform.Translate(vec);
    }
} 
