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
        //�ֱ� ���� ������ �����ð��� 0���� �ʱ�ȭ
        timeAfterSpawn = 0f;

        //ź�� ���� ������ min�� max ���̿��� ���� ����
        sPawnRate = Random.Range(spawnRateMin, spawnRateMax);
        

        //���� ��� ����
        target = FindObjectOfType<PlayerController>().transform;

    }

    // Update is called once per frame
    void Update()
    {
        //timeAfterSpawn ����
        Debug.Log(Time.deltaTime);
        timeAfterSpawn += Time.deltaTime;
        if(timeAfterSpawn >= sPawnRate)
        {
            timeAfterSpawn = 0f;

            //bulletPrefa�� �������� ����
            GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
            // ������ buleet ���� ������Ʈ�� ��������� target�� ���ϵ��� ȸ��
            bullet.transform.LookAt(target);
            //������ ���� ������ ���� ����
            sPawnRate = Random.Range(spawnRateMin, spawnRateMax);
        }



    }
}
