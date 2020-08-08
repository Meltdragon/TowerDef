using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletTower : Tower
{
    [SerializeField] private Transform bulletSpawnTransform;

    protected override void Shoot()
    {
        base.Shoot();
        GameObject bullet = Instantiate(stats.GetBulletType(), bulletSpawnTransform.position, Quaternion.identity);
        bullet.GetComponent<Bullet>().SetBulletAttributes(stats.GetDamageType(), stats.GetTowerBuff(), 
                                                          stats.GetTowerDamage(), stats.GetSplashRange(), stats.GetJumpTargets(), 
                                                          stats.GetBulletSpeed(), target);

    }
}
