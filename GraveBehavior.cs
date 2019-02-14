using UnityEngine;
using System.Collections;

public class GraveBehavior : MonoBehaviour 
{
	private Animator anim;
	
	void Start()
	{
		anim = GetComponent<Animator>();
	}
	void Update()
	{
	
	}
	
	void OnTriggerStay2D(Collider2D collider)
	{
		AttackerBehavior attacker = collider.gameObject.GetComponent<AttackerBehavior>();
		
		if(attacker)
		{
			anim.SetTrigger ("underAttackTrigger");
		}		
	}
}