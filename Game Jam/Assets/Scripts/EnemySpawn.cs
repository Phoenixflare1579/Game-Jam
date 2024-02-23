using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    // put differnt enemies in this array and later set it up to choose enemy based on game progression
    public GameObject[] spawnables;
    public float spawnRadius;
    public float spawnTimer;
    // rate that enemies spawn
    public float spawnRate;
    public float spawnTime;

    void Start()
    {

    }


    void Update()
    {
        float xpos = this.transform.position.x;
        float zpos = this.transform.position.z;
        float radian = Random.Range(0f, 2 * Mathf.PI);
        spawnTimer += Time.deltaTime;

        if (spawnTimer > spawnTime)
        {
            Instantiate(spawnables[0], new Vector3(xpos + spawnRadius * Mathf.Cos(radian), 0, zpos + spawnRadius * Mathf.Sin(radian)), Quaternion.identity);
            spawnTimer -= spawnTime;
            // enemies spawn faster as game progresses
            spawnTime -= spawnRate * Mathf.Pow(spawnTime,2);
        }
    }
}
