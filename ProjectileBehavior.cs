using UnityEngine;
using System.Collections;

public class ProjectileBehavior : MonoBehaviour 
{
	
	public float Speed;
	public float Damage;
	public bool destructible = true;
	private BoxCollider2D col;
	public bool Debuffer = false;


	// Use this for initialization
	void Start () 
	{
		col = GetComponent<BoxCollider2D>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		transform.Translate(Vector3.right * Speed * Time.deltaTime);
	}
	
	void OnTriggerEnter2D (Collider2D collider)
	{
		AttackerBehavior attacker = collider.gameObject.GetComponent<AttackerBehavior>();
		Health health = collider.gameObject.GetComponent<Health>();
		
		if(attacker && health)
		{
			health.DealDamage(Damage);
			if(Debuffer)
			{
				attacker.Debuff();
			}
			if(destructible == true)
			{
				Destroy(gameObject);
			}
		}
	}
	
	void ClearBomb()
	{
		col.enabled = false;
	}
	
	void Cleanup()
	{
		Destroy(gameObject);
	}
}