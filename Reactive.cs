using UnityEngine;
using System.Collections;

public class Reactive : MonoBehaviour 
{
	
	public GameObject projectile;
	public GameObject gun;
	public float fireCDSaved;
	public float fireCooldown;
	private GameObject projectileParent;
	private Animator anim;
	private Spawn myLaneSpawner;
	
	// Use this for initialization
	void Start () 
	{
		
		anim = GetComponent<Animator>();	
		//fireCooldown = fireCDSaved;
		projectileParent = GameObject.Find ("Projectiles");
		if(!projectileParent)
		{
			projectileParent = new GameObject("Projectiles");
		}
		
		SetMyLaneSpawner();
	}
	
	// Update is called once per frame
	void Update () 
	{
		fireCooldown -= 1 * Time.deltaTime;
		
		if(isAttackerInMelee())
		{
			//print(name + " found target");
			anim.SetBool ("isAttacking", true);
		}
		else
		{	
			//print(name + " No targets");
			anim.SetBool ("isAttacking",false);
		}
		
	}
	
	private void Fire()
	{
		if (fireCooldown <= 0)
		{
			GameObject newProjectile = Instantiate(projectile) as GameObject;
			newProjectile.transform.parent = projectileParent.transform;
			newProjectile.transform.position = gun.transform.position;
			fireCooldown = fireCDSaved;
		}
	}
		
	bool isAttackerInMelee()
	{
		if(myLaneSpawner.transform.childCount <= 0)
		{
			return false;
		}
		
		foreach(Transform attacker in myLaneSpawner.transform)
		{
			if (attacker.transform.position.x <= transform.position.x + 1)
			{
				//print ("Enemy in " + name + "'s lane");
				return true;
			}
		}
		
		return false;
	}
	
	void SetMyLaneSpawner()
	{
		Spawn[] spawnerArray = GameObject.FindObjectsOfType<Spawn>();
		
		foreach(Spawn spawner in spawnerArray)
		{
			if(spawner.transform.position.y == transform.position.y)
			{
				myLaneSpawner = spawner;
				//print (name + " is in lane " + spawner.transform.position.y);
				return;
			}
		}
		
		Debug.LogError ("Can't Find Spawner!!");
	}
	
	void SuicideSquad()
	{
		Destroy(gameObject);
	}
}