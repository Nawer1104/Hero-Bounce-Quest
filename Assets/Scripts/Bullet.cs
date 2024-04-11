using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject hitEffect;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
        Destroy(effect, 1f);

        if (collision != null && collision.gameObject.CompareTag("Enemy"))
        {
            collision.gameObject.GetComponent<Enemy>().Destroy();
        }

        if (collision != null && collision.gameObject.CompareTag("Boss"))
        {
            collision.gameObject.GetComponent<Boss>().GetHit();
        }

        Destroy(gameObject);
    }
}