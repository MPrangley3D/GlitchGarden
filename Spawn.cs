using UnityEngine;
using System.Collections;

public class Spawn : MonoBehaviour 
{
	public GameObject[] AttackerPrefabArray;
	private bool Warmup = false;


	void Start()
	{
		Invoke ("WarmupMethod",5f);
	}


	// Update is called once per frame
	void Update () 
	{
		if(Warmup)
		{
			foreach (GameObject thisAttacker in AttackerPrefabArray)
			{
				if (isTimeToSpawn(thisAttacker))
				{
					SpawnAttacker(thisAttacker);
				}
			}
		}
	}
	
	bool isTimeToSpawn(GameObject attackerGameObject)
	{
		AttackerBehavior attacker = attackerGameObject.GetComponent<AttackerBehavior>();
		
		float meanSpawnDelay = attacker.seenEverySeconds;
		float spawnsPerSecond = 1 / meanSpawnDelay;
		
		if(Time.fixedDeltaTime > meanSpawnDelay)
		{
			Debug.LogWarning ("Spawn Rate capped by Frame Rate");
		}
		
		float threshold = spawnsPerSecond * Time.deltaTime / 5;
		
		return (Random.value < threshold);
	}
	
	void SpawnAttacker(GameObject myGameObject)
	{
		GameObject myAttacker = Instantiate(myGameObject) as GameObject;
		myAttacker.transform.parent = transform;
		myAttacker.transform.position = transform.position;
	}
	
	void WarmupMethod()
	{
		Warmup = true;
	}
}
