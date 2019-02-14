using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Button : MonoBehaviour 
{
	
	public static GameObject selectedDefender;
	public GameObject Defender;
	
	private Text costText;
	private Button[] buttonArray;

	// Use this for initialization
	void Start () 
	{
		buttonArray = GameObject.FindObjectsOfType<Button>();
		foreach(Button thisButton in buttonArray)
		{
			thisButton.GetComponent<SpriteRenderer>().color = Color.grey;
		}
		
		costText = GetComponentInChildren<Text>();
		if(!costText)
		{
			Debug.LogWarning(name + " Has no cost text!!");
		}
		
		costText.text = Defender.GetComponent<DefenderBehavior>().cost.ToString ();
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}
	
	void OnMouseDown()
	{
		foreach(Button thisButton in buttonArray)
		{
			thisButton.GetComponent<SpriteRenderer>().color = Color.grey;
		}
		GetComponent<SpriteRenderer>().color = Color.white;
		selectedDefender = Defender;
	}
}
