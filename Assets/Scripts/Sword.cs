﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class Sword : MonoBehaviour, IWeapon
{
	private Animator animator;
	public List<BaseStat> Stats { get; set;}
	public CharacterStats CharacterStats{ get; set;}

	void Start()
	{
		animator = GetComponent<Animator> ();
	}


	public void PerformAttack()
	{
		animator.SetTrigger ("Base_Attack");
		Debug.Log (this.name + "attack!");
	}

	public void PerformSpecialAttack()
	{
		animator.SetTrigger ("Special_Attack");
	}

	void OnTriggerEnter(Collider col)
	{
		if (col.tag == "Enemy") 
		{
			col.GetComponent<IEnemy>().TakeDamage(CharacterStats.GetStat(BaseStat.BaseStatType.Power).GetCalculatedStatValue());
		}
		/*Debug.Log ("Hit" + col.name);*/
	}
}
