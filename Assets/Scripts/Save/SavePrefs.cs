using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavePrefs : MonoBehaviour
{
    public int levelsCleared;
	public static List<string> ClearedList = new List<string>();
	public float score;
    public float time;



    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    public void SaveGame()
	{
		levelsCleared = ClearedList.Count;
		PlayerPrefs.SetInt("SavedCleared", levelsCleared);
		PlayerPrefs.SetFloat("SavedScore", score);
		PlayerPrefs.SetFloat("SavedTime", time);
		PlayerPrefs.Save();
		Debug.Log("Game data saved!");
	}

	public void LoadGame()
	{
		levelsCleared = PlayerPrefs.GetInt("SavedCleared");
		score = PlayerPrefs.GetFloat("SavedScore");
		time = PlayerPrefs.GetFloat("SavedTime");
		Debug.Log("Game data loaded!");
		for (int i = 0; i < levelsCleared; i++)
		{
			ClearedList.Add("Level_" + i);
		}
	}

	public void ResetGame()
	{
		for (int i = 0; i < 20; i++)
		{
			PlayerPrefs.DeleteKey("Level_" + i);
			PlayerPrefs.DeleteKey("Level_" + i + "Time");
			PlayerPrefs.DeleteKey("Level_" + i + "Score");
			ClearedList.Clear();
			levelsCleared = 0;
		}
		PlayerPrefs.Save();
		Debug.Log("Game data reset!");
	}
}
