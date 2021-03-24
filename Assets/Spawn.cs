using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    // Start is called before the first frame update
    public float spawnRate;
    public GameObject[] enemies;
    public int waves;
    void Start()
    {
        InvokeRepeating("Spawner", spawnRate, spawnRate);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Spawner()
    {
        for (int i = 0; i < waves; i++)
        Instantiate(enemies[(int)Random.Range(0, enemies.Length)], new Vector3(Random.Range(-8.5f,8.5f),7,0), Quaternion.identity);
    }
}
