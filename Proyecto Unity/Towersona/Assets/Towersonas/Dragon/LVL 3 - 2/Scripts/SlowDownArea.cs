﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowDownArea : MonoBehaviour
{
	[HideInInspector] public DragonAttack pattern;

	private void FixedUpdate()
	{
		Collider[] colliders = Physics.OverlapSphere(transform.position, pattern.currentDamageArea);	

		foreach (Collider collider in colliders)
		{
			if (collider.CompareTag("Enemy"))
			{
				Enemy e = collider.GetComponent<Enemy>();
				if (e != null)
				{
					//e.AddSlowDown(dragonStats.currentSlowDownPercentage, dragonStats.currentSlowDownTime, SlowDownType.Area, gameObject);
					SlowDown slowDown = (SlowDown)TemporalEffect.CreateEffect(TemporalEffectType.SlowDown);
					slowDown.Initialize(pattern.currentSlowDownPercentage, pattern.currentSlowDownTime, e.gameObject);
					slowDown.ApplyEffect();
				}
			}
		}
	}

	public void SetRadius(float radius)
	{
		transform.localScale = Vector3.one * radius;
	}

	private void OnDrawGizmos()
	{
		/*Gizmos.color = Color.red;
		Gizmos.DrawWireSphere(transform.position, 1f);*/
	}
}
