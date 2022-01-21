using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletspawner : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform fireposition;
    private AudioSource audio;
    public AudioClip shooting;

    private LineRenderer bulletline;
    // Start is called before the first frame update
    void Start()
    {
        bulletline = GetComponent<LineRenderer>();
        bulletline.positionCount = 2;
        bulletline.enabled = false;

        audio = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetMouseButtonDown(0) && gamemanager.instance.remainammo > 0)
        {
            gamemanager.instance.remainammo--;
            //GameObject bullet = Instantiate(bulletPrefab, fireposition.position, fireposition.rotation);
            Shot();
            audio.PlayOneShot(shooting);

            
        }
    }
    private void Shot()
    {
        RaycastHit hit;
        Vector3 hitPosition = Vector3.zero;

        if (Physics.Raycast(fireposition.position, fireposition.up, out hit, 100f))
        {
            Debug.Log(hit.collider.name);
            Idamageable target = hit.collider.GetComponent<Idamageable>();

            if(target != null)
            {
                target.Ondamage(hit.point, hit.normal);
            }
            
            hitPosition = hit.point;
        }
        else
        {
            hitPosition = fireposition.position + fireposition.up * 100f;
        }
        StartCoroutine(ShotEffect(hitPosition));
    }

    private IEnumerator ShotEffect(Vector3 hitPosition)
    {
        bulletline.SetPosition(0, fireposition.position);
        bulletline.SetPosition(1, hitPosition);
        bulletline.enabled = true;

        yield return new WaitForSeconds(0.5f);

        bulletline.enabled = false;
    }
    
}
