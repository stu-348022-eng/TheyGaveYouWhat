using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyInteractions : MonoBehaviour
{
    public GameObject Loot;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "PlayerBullet")
        {
            DestroyEnemy();
        }
    }

    public void DestroyEnemy()
    {


        Spawnloot();
        
        Destroy(gameObject);
    }

    public void Spawnloot()
    {
        int RanVal = Random.Range(1, 11);
        if(RanVal >= 5)
        {
            Instantiate(Loot, transform.position, Quaternion.identity);
        }
    }
}
