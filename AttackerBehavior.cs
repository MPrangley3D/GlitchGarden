using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
public class AttackerBehavior : MonoBehaviour 
{
	public float walkSpeed;
	private GameObject currentTarget;
	private Animator anim;
	[Tooltip("Average Seconds per Spawn")]
	public float seenEverySeconds;
	private bool Slowed = false;

	void Start()
	{
		anim = GetComponent<Animator>();
	}


	// Update is called once per frame
	void Update () 
	{
		if(!currentTarget)
		{
			anim.SetBool("isAttacking", false);
		}
		if(!Slowed)
		{
			transform.Translate(Vector3.left * (walkSpeed/2) * Time.deltaTime);
		}
		else if(Slowed)
		{
			transform.Translate(Vector3.left * (walkSpeed/3) * Time.deltaTime);
		}
	}
	
	void OnTriggerEnter2D()
	{
		//Debug.Log (name + " trigger enter");
	}
	
	public void SetSpeed(float speed)
	{
		walkSpeed = speed;
	}
	
	public void StrikeCurrentTarget(float damage)
	{
		if(currentTarget)
		{
			Health hp = currentTarget.GetComponent<Health>();
			if(hp)
			{
				hp.DealDamage(damage);
			}
		}
	}
	
	public void Attack(GameObject obj)
	{
		currentTarget = obj;	
	}
	
	public void Debuff()
	{
		if(!Slowed)
		{
			Slowed = true;
		}
	}
}