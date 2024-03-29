﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : Shooting
{
    protected override void HitTarget()
    {
        Enemy e = target.parent.GetComponent<Enemy>();

        Vector3 pos = transform.position;

        pos.y += 1f;   

        BuildManager.Instance.SpawnEffect(impactEffect, pos);        

        if (e != null)
        {
            e.TakeDamage(pattern.AttackStrength);
        }

        Destroy(gameObject);
    }
}
