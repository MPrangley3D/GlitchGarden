﻿using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AttackerBehavior))]
public class StandardAttacker : MonoBehaviour 
{
	
	private Animator anim;
	private AttackerBehavior atkbehave;
	
	// Use this for initialization
	void Start () 
	{
		anim = GetComponent<Animator>();
		atkbehave = GetComponent<AttackerBehavior>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}
	
	void OnTriggerEnter2D(Collider2D collider)
	{
		GameObject obj = collider.gameObject;
		
		if(!obj.GetComponent<DefenderBehavior>())
		{
			return;
		}
		else
		{
			anim.SetBool ("isAttacking", true);
			atkbehave.Attack(obj);
		}
	}
}