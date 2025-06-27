using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public List<GameObject> Enemies = new List<GameObject>();
    public float spawnRate;
    public GameObject playerRef;

    public Vector2 spawnArea = new Vector2(5f, 5f);

    void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    IEnumerator SpawnEnemies()
    {
        while (true)
        {
            Vector2 offset = new Vector2(Random.Range(-spawnArea.x, spawnArea.x), Random.Range(-spawnArea.y, spawnArea.y));
            Vector3 spawnPos = transform.position + (Vector3)offset;

            GameObject spawned = Instantiate(Enemies[0], spawnPos, Quaternion.identity);

            EnemyAttack attack = spawned.GetComponent<EnemyAttack>();
            if (attack != null && playerRef != null)
            {
                attack.GetType()
                    .GetField("player", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)
                    ?.SetValue(attack, playerRef);
            }

            yield return new WaitForSeconds(spawnRate);
        }
    }
}
