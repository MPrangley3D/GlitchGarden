using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class OptionsController : MonoBehaviour 
{
	public Slider volumeSlider;
	//public Slider diffSlider;
	public LevelManager levelManager;
	
	private MusicPlayer musicPlayer;


	// Use this for initialization
	void Start () 
	{
		musicPlayer = GameObject.FindObjectOfType<MusicPlayer>();
		
		volumeSlider.value = PlayerPrefsManager.GetMasterVolume();
		//diffSlider.value = PlayerPrefsManager.GetDiff();
	}
	
	// Update is called once per frame
	void Update () 
	{
		musicPlayer.ChangeVolume(volumeSlider.value);
	}
	
	public void SaveAndExit()
	{
		PlayerPrefsManager.SetMasterVolume(volumeSlider.value);
		//PlayerPrefsManager.SetDiff(diffSlider.value);
		levelManager.LoadLevel("01_Start");
	}
	
	public void Defaults()
	{
		volumeSlider.value = 0.75f;
		//diffSlider.value = 1f;
	}
}
