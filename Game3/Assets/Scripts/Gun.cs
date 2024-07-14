using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    // Start is called before the first frame update
    private float angle;

    public GameObject bullet;
    public GameObject muzzle;

    public Transform Firepos;
    AudioManager audioManager;

    public float TimeBtwFire;
    public float FireForce;
    // Update is called once per frame
    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }
    void Update()
    {
        
        RotateGun();
        TimeBtwFire -= Time.deltaTime;
        if(Input.GetMouseButton(0) && TimeBtwFire < 0)
        {
            FireBullet();
        }
    }

    void RotateGun()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 lookDir = mousePos - transform.position;
        angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;

        Quaternion rotation = Quaternion.Euler(0, 0, angle);
        transform.rotation = rotation;

        if (transform.eulerAngles.z > 90 && transform.eulerAngles.z < 270)
        {
            transform.localScale = new Vector3(0.5f, -0.5f, 0);
        }
        else
        {
            transform.localScale = new Vector3(0.5f, 0.5f, 0);
        }
            
    }
    void FireBullet()
    {
        TimeBtwFire = 0.3f;
        audioManager.PlaySFX(audioManager.shoot , 1);
        GameObject buttetRb = Instantiate(bullet, Firepos.position, Quaternion.identity);
        Instantiate(muzzle, Firepos.position, transform.rotation, transform);
        Rigidbody2D rb = buttetRb.GetComponent<Rigidbody2D>();
        rb.AddForce(transform.right * FireForce, ForceMode2D.Impulse);
    }
    
}
