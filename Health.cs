using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour 
{

	public float HP;
	private Animator anim;

	public void DealDamage(float damage)
	{
		HP -= damage;	
		if(HP <= 0)
		{
			//anim.SetBool("Dead");
			KillObject();
		}
	}
	
	public void KillObject()
	{
		Destroy (gameObject);
	}
}
