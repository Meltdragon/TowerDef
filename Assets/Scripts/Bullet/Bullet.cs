using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private DamageType damageType;
    private TowerBuffs towerBuffs;

    private Vector3 target;
    private Vector3 direction;

    private int damage;
    private int splashRange;
    private int jumpTarget;
    private float bulletSpeed;

    public void SetBulletAttributes(DamageType damageType, TowerBuffs towerBuffs, int damage, int splashRange, int jumpTarget, float bulletSpeed, Vector3 target)
    {
        this.damageType = damageType;
        this.towerBuffs = towerBuffs;
        this.damage = damage;
        this.splashRange = splashRange;
        this.jumpTarget = jumpTarget;
        this.bulletSpeed = bulletSpeed;
        this.target = target;
        SetDirection();
    }

    private void SetDirection()
    {
        
        direction = (target - gameObject.transform.position).normalized;
    }

    private void FixedUpdate()
    {
        gameObject.GetComponent<Rigidbody>().velocity = direction * bulletSpeed;
        if (Vector3.Distance(target, gameObject.transform.position) >= 100)
        {
            RangeDestroy();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            switch(damageType)
            {
                case DamageType.SingleTarget:
                    {
                        collision.gameObject.GetComponent<iDamageAble>().DamageTaken(damage);
                        break;
                    }
                case DamageType.SplashTarget:
                    {
                        break;
                    }
                case DamageType.JumpTarget:
                    {
                        break;
                    }
            }
        }
        Destroy(gameObject);
    }

    private void RangeDestroy()
    {
        Destroy(gameObject);
    }
}