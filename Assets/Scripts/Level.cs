using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    public GameObject[] enemyPrefabs;

    public GameObject boss;

    public Transform[] spawnPoints;

    public List<Enemy> enemies;

    private float delay = 1f;

    public int maxZombie = 30;

    public GameObject vfxSpawn;

    bool isBossSpawned;

    public int bossNumbers = 1;

    private void Awake()
    {
        isBossSpawned = false;
    }

    private void Update()
    {
        if (enemies.Count < maxZombie)
        {
            if (delay <= 0)
            {
                delay = 1f;
                Vector2 spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)].position;
                GameObject enemy = Instantiate(enemyPrefabs[Random.Range(0, enemyPrefabs.Length)], spawnPoint, Quaternion.identity);
                GameObject vfx = Instantiate(vfxSpawn, spawnPoint, Quaternion.identity);
                Destroy(vfx, 1f);
                enemies.Add(enemy.GetComponent<Enemy>());
            }
            else
            {
                delay -= Time.deltaTime;
            }
        }
        else
        {
            if (isBossSpawned) return;

            SpawnBoss();
            isBossSpawned = true;
        }
    }

    private void SpawnBoss()
    {
        Vector2 spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)].position;
        GameObject boss = Instantiate(this.boss, spawnPoint, Quaternion.identity);
        GameObject vfx = Instantiate(vfxSpawn, spawnPoint, Quaternion.identity);
        Destroy(vfx, 1f);
    }
}
