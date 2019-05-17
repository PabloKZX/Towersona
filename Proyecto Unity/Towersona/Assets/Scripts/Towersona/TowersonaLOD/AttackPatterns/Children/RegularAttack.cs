﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RegularAttack : AttackPattern
{
  
    public override void Shoot(Transform target)
    {
        GameObject bulletObject = Instantiate(bulletPrefab, towersonaLOD.firePoint.position, towersonaLOD.firePoint.rotation);
        bulletObject.transform.SetParent(GameObject.FindGameObjectWithTag("Bullets Parent").transform, true);
        Bullet bullet = bulletObject.GetComponent<Bullet>();
        bullet.damage = stats.currentAttackStrength;
        bullet.speed = stats.currentBulletSpeed;

        if (bullet != null) bullet.Seek(target);  
    }

    public override void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;

        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }

        if (nearestEnemy != null && shortestDistance <= stats.currentAttackRange)
        {
            target = nearestEnemy.transform;
        }
        else
        {
            target = null;
        }
    }

}