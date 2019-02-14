using UnityEngine;
using System.Collections;

public class MusicPlayer : MonoBehaviour 
{
	public AudioClip[] LevelMusicChangeArray;
	private AudioSource audioSource;	
	
	void Awake()
	{
		DontDestroyOnLoad(gameObject);
	}
	
	void Start()
	{
		audioSource = GetComponent<AudioSource>();
	}
	
	void OnLevelWasLoaded(int level)
	{
		AudioClip currentMusic = LevelMusicChangeArray[level];
		if(currentMusic)
		{
			audioSource.clip = currentMusic;
			audioSource.loop = true;
			audioSource.Play ();
			audioSource.volume = PlayerPrefsManager.GetMasterVolume();
		}
	}
	
	public void ChangeVolume(float volume)
	{
		audioSource.volume = volume;
	}
	

}