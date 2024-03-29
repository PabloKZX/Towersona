﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Shooting : MonoBehaviour
{  
    [SerializeField][Tooltip("Particle System when a bullet hits")]
    protected GameObject impactEffect;

	[HideInInspector]public GameObject source;
	[HideInInspector] public AttackPattern pattern;

	protected Transform target;

	public virtual void Seek(Transform _target)
    {
        target = _target.GetChild(0).transform;
    }

    protected virtual void Update()
    {
        if(target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 dir = target.position - transform.position;
        float distanceThisFrame = pattern.currentBulletSpeed * Time.deltaTime;

        if(dir.magnitude <= distanceThisFrame)
        {
            HitTarget();
            return;
        }

        transform.Translate(dir.normalized * distanceThisFrame, Space.World);
        transform.LookAt(target);
    }

    protected abstract void HitTarget();   
}
