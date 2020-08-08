using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour, iDamageAble 
{
    [ShowNonSerializedField] protected int health;
    [ShowNonSerializedField] private int movementSpeed;

    private List<GameObject> wayPoints;

    [SerializeField] private float maxDistance;

    [SerializeField] protected Stats stats;
    [SerializeField] protected StatsUpgrade statsUpgrade;

    public List<GameObject> WayPoints { get => wayPoints; }
    public float MaxDistance { get => maxDistance; }
    public int MovementSpeed { get => movementSpeed; }

    protected virtual void Start()
    {
        SetStats();
        GetWayPoints();
        EnemyStorageHandler.AddEnemy(this.gameObject);
    }

    public void DamageTaken(int damage)
    {
        health -= damage;
        if(health <= 0)
        {
            AddMoney();
            Death();
        }
    }

    public void Death()
    {
        EnemyStorageHandler.RemoveEnemy(this.gameObject);
        Destroy(gameObject);
    }

    public virtual void SetStats()
    {
        health = stats.health + Mathf.RoundToInt(stats.health * statsUpgrade.healthUpgradeInPercent.Evaluate(0));
        movementSpeed = stats.movementSpeed + Mathf.RoundToInt(stats.movementSpeed * statsUpgrade.healthUpgradeInPercent.Evaluate(0));
    }

    private void GetWayPoints()
    {
        wayPoints = new List<GameObject>(WayPointSystem.GetWayPoints());
    }

    public void RemoveFromList()
    {
        wayPoints.Remove(wayPoints[0]);
    }

    private void AddMoney()
    {
        MoneyHandler.AddMoney(stats.money);
    }
}
