using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Tower : MonoBehaviour
{
    [SerializeField] protected TowerStats stats;
    [SerializeField] private TowerHead towerHead;

    [EnableIf("IsTowerHeadMobile")]
    [SerializeField] private GameObject mobileHead;

    private Timer rPM;
    private int health;
    protected GameObject target;

    void Start()
    {
        rPM = new Timer();
        rPM.SetTimer(stats.GetRPM());
        health = stats.GetTowerHealth();
        target = null;
    }

    protected virtual void Update()
    {
        if (IsTowerHeadMobile() && target != null)
        {
            MoveHead();
        }
        if(target != null)
        {
            rPM.Tick();
        }
        if(rPM.CurrentTime <= 0)
        {
            Shoot();
        }
    }

    protected virtual void FixedUpdate()
    {
        if (target == null)
        {
            FindEnemy();
        }
        if(target != null)
        {
            CheckRange();
        }
    }

    private void MoveHead()
    {
        Vector3 direction = target.transform.position - mobileHead.transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(direction);
        Vector3 rotation = lookRotation.eulerAngles;
        mobileHead.transform.rotation = Quaternion.Euler(0, rotation.y, 0);
    }

    protected virtual void Shoot()
    {
        rPM.Reset();
    }

    private void FindEnemy()
    {
        foreach (GameObject enemy in EnemyStorageHandler.Enemies)
        {
            if (target == null)
            {
                if (Vector3.Distance(enemy.transform.position, gameObject.transform.position) <= stats.GetTowerRange())
                {
                    target = enemy;
                }
            }
            else
            {
                if (Vector3.Distance(enemy.transform.position, gameObject.transform.position) <= stats.GetTowerRange() &&
                    Vector3.Distance(enemy.transform.position, gameObject.transform.position) < Vector3.Distance(target.transform.position, gameObject.transform.position))
                {
                    target = enemy;
                }
            }
        }
    }

    private void CheckRange()
    {
        if(stats.GetTowerRange() < Vector3.Distance(target.transform.position, gameObject.transform.position))
        {
            target = null;
        }
    }

    protected bool IsTowerHeadMobile()
    {
        return towerHead == TowerHead.Mobile;
    }
}

public enum TowerHead
{
    Static,
    Mobile
}