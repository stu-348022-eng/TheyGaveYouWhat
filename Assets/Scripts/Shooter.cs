using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    public bool canShoot = true;
    public Transform target;
    public GameObject projectilePrefab;
    public float range = 10f;
    public float fireRate = 1f;
    public float projectileSpeed = 20f;

    float _cooldown;

    void Update()
    {
        if (!canShoot || target == null || projectilePrefab == null) return;
        if (Vector2.Distance(transform.position, target.position) > range) return;

        _cooldown -= Time.deltaTime;
        if (_cooldown > 0f) return;

        _cooldown = 1f / fireRate;
        Shoot();
    }

    void Shoot()
    {
        Vector2 dir = ((Vector2)target.position - (Vector2)transform.position).normalized;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        GameObject p = Instantiate(projectilePrefab, transform.position, Quaternion.Euler(0f, 0f, angle));
        if (p.TryGetComponent<Rigidbody2D>(out var rb))
            rb.velocity = dir * projectileSpeed;
    }
}
