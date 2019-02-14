using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameTimer : MonoBehaviour 
{
	
	public float levelTime;
	private Slider slider;
	private AudioSource audioSource;
	private bool isEndOfLevel = false;
	private LevelManager levelManager;
	private GameObject winLabel;
	private GameObject loseZone;
	private GameObject attackers;
	private GameObject defenders;
	private GameObject projectiles;
	
	// Use this for initialization
	void Start () 
	{
	 slider = GetComponent<Slider>();
	 audioSource = GetComponent<AudioSource>();
	 slider.maxValue = levelTime;
	 slider.minValue = 0f;
	 slider.value = levelTime;
	 levelManager = GameObject.FindObjectOfType<LevelManager>();
	 loseZone = GameObject.Find("LoseZone");
	 
	 FindYouWin();
	 winLabel.SetActive (false);
	}
	
	void FindYouWin()
	{
		winLabel = GameObject.Find ("Win Popup");
		if(!winLabel)
		{
			Debug.LogWarning ("No Win popup found");
		}
	}
	
	// Update is called once per frame
	void Update () 
	{
		slider.value -= Time.deltaTime;
		if(slider.value <= 0 && !isEndOfLevel)
		{
			ClearScreen ();
			audioSource.Play ();
			winLabel.SetActive (true);
			loseZone.SetActive(false);
			Invoke ("LoadNextLevel",audioSource.clip.length);
			isEndOfLevel = true;
		}
	}
	
	void LoadNextLevel()
	{
		levelManager.LoadNextLevel();
	}
	
	void ClearScreen()
	{
		attackers = GameObject.Find("Spawners").gameObject;
		defenders = GameObject.Find("Defenders").gameObject;
		projectiles = GameObject.Find("Projectiles").gameObject;
		
		projectiles.SetActive(false);
		attackers.SetActive(false);
		defenders.SetActive(false);
	}
}
