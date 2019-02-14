using UnityEngine;
using System.Collections;

public class DefenderSpawner : MonoBehaviour 
{

	public Camera myCamera;
	private GameObject parent;
	private Display starDisplay;


	void Start()
	{
		parent = GameObject.Find ("Defenders");
		if(!parent)
		{
			parent = new GameObject("Defenders");
		}
		
		starDisplay = GameObject.FindObjectOfType<Display>();
	}

	void OnMouseDown()
	{
		Vector2 rawPos = CalculateWorldPointOfMouseClick();
		Vector2 roundedPos = SnapToGrid(rawPos);
		GameObject defender = Button.selectedDefender;
		
		int defenderCost = defender.GetComponent<DefenderBehavior>().cost;
		if(starDisplay.UseStars (defenderCost) == Display.Status.SUCCESS)
		{
			SpawnDefender(roundedPos, defender);
		}
		else
		{
			Debug.Log ("Not enough $$$");
		}
	}
	
	void SpawnDefender(Vector2 roundedPos, GameObject defender)
	{
		Quaternion zeroRot = Quaternion.identity;		
		GameObject newDef = Instantiate(defender, roundedPos, zeroRot) as GameObject;
		newDef.transform.parent = parent.transform;
	}
	
	Vector2 CalculateWorldPointOfMouseClick()
	{
		float mouseX = Input.mousePosition.x;
		float mouseY = Input.mousePosition.y;
		float distanceFromCamera = 10f;
		
		Vector3 weirdTriplet = new Vector3(mouseX, mouseY, distanceFromCamera);
		Vector2 worldPos = myCamera.ScreenToWorldPoint(weirdTriplet);
		
		return worldPos;
	}
	
	Vector2 SnapToGrid(Vector2 rawWorldPos)
	{
		float newX = Mathf.RoundToInt(rawWorldPos.x + 0.3f);
		float newY = Mathf.RoundToInt(rawWorldPos.y + 0.1f);
		
		return new Vector2 (newX, newY);		
	}
}