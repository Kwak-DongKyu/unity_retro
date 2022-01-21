using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{

    public GameObject bulletPrefab;
    public float spawnRateMin = 0.5f;
    public float spawnRateMax = 3f;

    private Transform target;
    private float sPawnRate;
    private float timeAfterSpawn;
    // Start is called before the first frame update
    void Start()
    {
        //최근 생성 이후의 누적시간을 0으로 초기화
        timeAfterSpawn = 0f;

        //탄알 생성 간격을 min과 max 사이에서 랜덤 지정
        sPawnRate = Random.Range(spawnRateMin, spawnRateMax);
        

        //조준 대상 설정
        target = FindObjectOfType<PlayerController>().transform;

    }

    // Update is called once per frame
    void Update()
    {
        //timeAfterSpawn 갱신
        Debug.Log(Time.deltaTime);
        timeAfterSpawn += Time.deltaTime;
        if(timeAfterSpawn >= sPawnRate)
        {
            timeAfterSpawn = 0f;

            //bulletPrefa의 복제본을 생성
            GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
            // 생성된 buleet 게임 오브젝트의 정면방향이 target을 향하도록 회전
            bullet.transform.LookAt(target);
            //다음번 생성 간격을 랜덤 지정
            sPawnRate = Random.Range(spawnRateMin, spawnRateMax);
        }



    }
}
