using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStorageHandler : Singleton<EnemyStorageHandler>
{
    private List<GameObject> enemies = new List<GameObject>();

    public static List<GameObject> Enemies { get => Instance.enemies; }

    public static void AddEnemy(GameObject enemy)
    {
        Instance.enemies.Add(enemy);
    }

    public static void RemoveEnemy(GameObject enemy)
    {
        Instance.enemies.Remove(enemy);
    }
}