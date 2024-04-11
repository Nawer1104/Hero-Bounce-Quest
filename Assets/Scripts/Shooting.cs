using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Transform firePoint;
    public GameObject[] bulletPrefabs;
    public CameraShake cameraShake;
    public float bulletForce = 20f;

    Vector2 mousePos;

    Rigidbody2D rb;

    float delay = 1f;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
            StartCoroutine(cameraShake.Shake(.15f, .1f));
        }

        delay = 1f;

    }

    private void FixedUpdate()
    {
        Vector2 lookDir = mousePos - rb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;

        rb.rotation = angle;
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefabs[Random.Range(0, bulletPrefabs.Length)], firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
    }
}