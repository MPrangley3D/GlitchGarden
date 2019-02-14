using UnityEngine;
using System.Collections;

public class PlayerPrefsManager : MonoBehaviour 
{
	const string MASTER_VOLUME_KEY = "master_volume";
	const string DIFF_KEY = "difficulty";
	const string LEVEL_KEY = "level_unlocked_";
	
	public static void SetMasterVolume(float volume)
	{
		if(volume >= 0f && volume <= 1f)
		{
			PlayerPrefs.SetFloat (MASTER_VOLUME_KEY,volume);
		}
		else
		{
			Debug.LogError ("Master Volume set out of range!");
		}
	}
	
	public static float GetMasterVolume()
	{
		return PlayerPrefs.GetFloat(MASTER_VOLUME_KEY);
	}
	
	public static void UnlockLevel (int level)
	{
		if(level <= Application.levelCount - 1)
		{
			PlayerPrefs.SetInt (LEVEL_KEY + level.ToString (), 1);  //Use 1 for True
		}
		else
		{
			Debug.LogError ("Trying to unlock level outside of build order!");
		}
	}
	
	public static bool IsLevelUnlocked(int level)
	{
		int levelValue = PlayerPrefs.GetInt (LEVEL_KEY + level.ToString());
		bool isLevelUnlocked = (levelValue == 1);
		
		if(level <= Application.levelCount - 1)
		{
			return isLevelUnlocked;
		}
		else
		{
			Debug.LogError ("Asking for level outside of build order!");
			return false;
		}
	}
	
	public static void SetDiff(float diff)
	{
		if(diff >= 1f && diff <= 3f)
		{
			PlayerPrefs.SetFloat(DIFF_KEY, diff);
		}
		else
		{
			Debug.LogError("Difficulty Setting out of bounds!");
		}
	}
	
	public static float GetDiff()
	{
		return PlayerPrefs.GetFloat(DIFF_KEY);
	}

}