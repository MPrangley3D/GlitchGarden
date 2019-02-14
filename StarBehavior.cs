using UnityEngine;
using System.Collections;

public class StarBehavior : MonoBehaviour 
{
	public float spawnCDSaved;
	private float spawnCooldown;
	private Animator anim;
	public int value;
	private Display starDisplay;
	
	// Use this for initialization
	void Start () 
	{
		anim = GetComponent<Animator>();
		spawnCooldown = spawnCDSaved;
		starDisplay = GameObject.FindObjectOfType<Display>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		spawnCooldown -= 1 * Time.deltaTime;
		
		if (spawnCooldown <= 0)
		{
			anim.SetTrigger ("SpawnStar");
			spawnCooldown = spawnCDSaved;
			AddStars (value);
		}
	}
	
	public void AddStars(int amount)
	{
		//print (amount);
		starDisplay.AddStars(amount);
	}
}
