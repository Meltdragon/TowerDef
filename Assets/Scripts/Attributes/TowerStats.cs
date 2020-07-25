using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TowerStats", menuName = "Tower Stats", order = 1)]
public class TowerStats : ScriptableObject
{
    [SerializeField] private GameObject bulletType;
    [SerializeField] private TowerBuffs towerBuff;
    [SerializeField] private DamageType damageType;
    [SerializeField] private int towerDamage;
    [SerializeField] private int towerHealth;
    [SerializeField] private int towerRange;
    [SerializeField] private float rPM;
    [SerializeField] private float bulletSpeed;
    [EnableIf("HasSplashDamage")]
    [SerializeField] private int splashRange;
    [EnableIf("HasJumpDamage")]
    [SerializeField] private int jumpTargets;

    public GameObject GetBulletType()
    {
        return bulletType;
    }

    public TowerBuffs GetTowerBuff()
    {
        return towerBuff;
    }

    public DamageType GetDamageType()
    {
        return damageType;
    }

    public int GetTowerDamage()
    {
        return towerDamage;
    }

    public float GetRPM()
    {
        return rPM;
    }

    public int GetTowerHealth()
    {
        return towerHealth;
    }

    public int GetTowerRange()
    {
        return towerRange;
    }

    public int GetSplashRange()
    {
        return splashRange;
    }

    public int GetJumpTargets()
    {
        return jumpTargets;
    }

    public float GetBulletSpeed()
    {
        return bulletSpeed;
    }

    public bool HasSplashDamage()
    {
        return damageType == DamageType.SplashTarget;
    }

    public bool HasJumpDamage()
    {
        return damageType == DamageType.JumpTarget;
    }
}

public enum TowerBuffs
{
    None,
    Slow
}

public enum DamageType
{
    SingleTarget,
    SplashTarget,
    JumpTarget
}