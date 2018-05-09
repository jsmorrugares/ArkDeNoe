﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Slime : MonoBehaviour , IEnemy
{
	public LayerMask aggroLayerMask;
	public float currentHealth;
	public float maxHealth;
	private Player player;
	private CharacterStats characterStats;
	private NavMeshAgent navAgent;
	private Collider[] withinAggroColliders;

	void Start()
	{
		navAgent = GetComponent<NavMeshAgent>();
		characterStats = new CharacterStats (6,10,2);
		currentHealth = maxHealth;
	}

	void FixedUpdate()
	{
		withinAggroColliders = Physics.OverlapSphere (transform.position, 10, aggroLayerMask);
		if(withinAggroColliders.Length > 0)
		{
			ChasePlayer (withinAggroColliders [0].GetComponent<Player>());
			/*Debug.Log ("found Player");*/
		}
	}

	public void PerformAttack()
	{
		player.TakeDamage (5);
	}
	public void TakeDamage(int amount)
	{
		currentHealth -= amount;
		if (currentHealth <= 0)
			Die ();
	}
	void ChasePlayer(Player player)
	{
		navAgent.SetDestination (player.transform.position);
		this.player = player;
		if (navAgent.remainingDistance <= navAgent.stoppingDistance) {
			if (!IsInvoking ("PerformAttack"))
				InvokeRepeating ("PerformAttack", .5f, 2f);
		}
		else 
		{
			Debug.Log ("Not Within distance");

			CancelInvoke ("PerformAttack");
		}

	}

	void Die()
	{
		Destroy (gameObject);
	}
		

}
