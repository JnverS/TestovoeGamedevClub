using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private List<Enemy> enemyPrefabs;
    [SerializeField] private Rigidbody2D player;
    private Enemy _enemy;

    void Awake()
    {
        if (enemyPrefabs.Count <= 0)
        {
            Debug.LogWarning("There are no enemies to spawn.");
            return;
        }
        SpawnEnemies();
    }

    void SpawnEnemies()
    {
        int randEnemy;
        for (int i = 0; i < 3; i++)
        {
            randEnemy = Random.Range(0, enemyPrefabs.Count);
            _enemy = enemyPrefabs[randEnemy];

            float posX = Random.Range(-37f, 130f);
            float posY = Random.Range(8.4f, -15.7f);
            var spawnedEnemy = Instantiate(_enemy, new Vector3(posX, posY, 0), Quaternion.identity);
            spawnedEnemy.GetComponent<Enemy>().GiveTarget(player);
        }
    }
}
