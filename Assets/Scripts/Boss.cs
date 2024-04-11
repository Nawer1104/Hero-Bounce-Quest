using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public float speed = 2;

    private Vector3 startPos;

    public GameObject vfxOnDeath;

    public int heath;

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

    public void GetHit()
    {
        heath -= 1;
        if (heath <= 0)
        {
            Destroy();
        }
    }

    public void Destroy()
    {
        GameManager.Instance.levels[GameManager.Instance.GetCurrentIndex()].bossNumbers -= 1;
        GameObject vfx = Instantiate(vfxOnDeath, transform.position, Quaternion.identity);
        Destroy(vfx, 1f);
        gameObject.SetActive(false);
        GameManager.Instance.CheckLevelUp();
    }
}
