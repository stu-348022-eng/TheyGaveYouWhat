using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    public float bulletForce;
    public PlayerMovement playermovescrpt;
    public GameObject player;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        
        if (playermovescrpt.FacingLeft)
        {
            rb.AddForce(-firePoint.right * bulletForce, ForceMode2D.Impulse);
            iTween.PunchScale(player, new Vector2(-1.1f, 1.1f), 0.1f);
        }
        else if(!playermovescrpt.FacingLeft)
        {
            rb.AddForce(firePoint.right * bulletForce, ForceMode2D.Impulse);
            iTween.PunchScale(player, new Vector2(1.1f, 1.1f), 0.1f);
        }
        

    }
}
