using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawningSystem : Singleton<SpawningSystem>
{
    [SerializeField] private SpawnOptions enemySpawn;
    [SerializeField] private float timeBetweenSpawns;

    private bool spawning = false;

    private void Update()
    {
        if (!spawning)
        {
            spawning = true;
            StartCoroutine("SpawnWaiting");
        }
    }

    private IEnumerator SpawnWaiting()
    {
        WaitForSeconds wait = new WaitForSeconds(timeBetweenSpawns);
        yield return wait;
        for (int i = 0; i < enemySpawn.enemy.Count; i++)
        {
            for (int j = 0; j < Mathf.RoundToInt(enemySpawn.amountOfEnemies.Evaluate(i)); j++)
            {
                Instantiate(enemySpawn.enemy[i], WayPointSystem.GetStartPoint().position, Quaternion.identity);
                yield return wait;
            }
        }
    }
}