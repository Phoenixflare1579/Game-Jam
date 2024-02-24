using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    // put differnt enemies in this array and later set it up to choose enemy based on game progression
    public GameObject[] spawnables;
    public float spawnRadius;
    // enemies per second
    public float spawnTimer;
    public float spawnIncreaseRate;

    private IEnumerator coroutine;

    void Start()
    {
        transform.localPosition = new Vector3(0, 0, 0);
        coroutine = SpawnEnemy();
        StartCoroutine(coroutine);
    }

    private IEnumerator SpawnEnemy()
    {
        while (true)
        {
            float xpos = transform.position.x;
            float zpos = transform.position.z;
            float radian = Random.Range(0f, 2 * Mathf.PI);

            int randomFish = Random.Range(0, spawnables.Length);
            
            Instantiate(spawnables[randomFish], new Vector3(xpos + spawnRadius * Mathf.Cos(radian), 0, zpos + spawnRadius * Mathf.Sin(radian)), Quaternion.identity);

            yield return new WaitForSeconds(spawnTimer);
            spawnTimer -= spawnIncreaseRate * Mathf.Pow(spawnTimer, 2);
        }
    }
}
