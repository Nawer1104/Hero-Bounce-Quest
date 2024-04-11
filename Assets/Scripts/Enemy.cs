using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 2;

    private Vector3 startPos;

    public GameObject vfxOnDeath;

    private void Awake()
    {
        startPos = transform.position;
    }

    private void Update()
    {
        transform.position += new Vector3(0f, speed * Time.deltaTime, 0f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision != null && collision.gameObject.CompareTag("Barrier"))
        {
            transform.position = startPos;
        }
    }

    public void Destroy()
    {
        GameObject vfx = Instantiate(vfxOnDeath, transform.position, Quaternion.identity);
        Destroy(vfx, 1f);
        gameObject.SetActive(false);
    }
}