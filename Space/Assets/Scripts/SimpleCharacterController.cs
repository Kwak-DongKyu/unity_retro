using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleCharacterController : MonoBehaviour
{
    [SerializeField]
    private Animator animator;
    Camera characterCamera;

    public GameObject bulletPrefab;

    /*
    void Fire()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //총알 발사위치는 캐릭터보다 살짝 정면
            Vector3 firePos = transform.position + animator.transform.forward + new Vector3(0f, 0.5f, 0f);
            
            //bullet으로 인스턴스화
            var bullet = Instantiate(bulletPrefab, firePos, Quaternion.identity).GetComponent<Bullet>(); 

            bullet.Fire(animator.transform.forward);
        }
    }
    */

    private void Awake()
    {
        characterCamera= GetComponentInChildren<Camera>();
    }
    // Update is called once per frame
    void Update()
    {

        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        Vector3 moveVector = new Vector3(moveX, 0f, moveZ);
        // 무브 벡터의 길이가 0이 아니면 키 입력이 들어오는 것으로 판정
        bool isMove = moveVector.magnitude > 0;
        // 애니메이터의 isMove의 값을 무브 벡터의 길이에 따라서 바뀌도록 함
        animator.SetBool("isMove", isMove);
        LookMouseCursor();
       

        // 유니티 엔진 1 단위는 1미터
        transform.Translate(new Vector3(moveX, 0f, moveZ).normalized * Time.deltaTime * 5f);
    }

    public void LookMouseCursor()
    {
        //screenpointtoray는 스크린 공간상의 좌표를3d공간 상의 카메라에서 발사되는 ray 라는 광선으로 바꿈

        Ray ray = characterCamera.ScreenPointToRay(Input.mousePosition);

        RaycastHit hit;
        if(Physics.Raycast(ray, out hit))//physics.raycast는 ray의 여러정보를 가져와서 raycasthit구조인 hit에 저장시킴
        {
            Vector3 mouseDir = new Vector3(hit.point.x, transform.position.y, hit.point.z) - transform.position; //ray와 충돌하는 x, z좌표만 받고 y좌표는 물체의 좌표를 그대로 사용.
            
            transform.LookAt(transform.position + mouseDir);
        } 
    }
}
