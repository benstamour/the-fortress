using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// script that stores game data so that it is saved if a new scene loads or if the current scene reloads
public class GameManager : MonoBehaviour
{
	private int score = 0; // number of orbs collected
	private float timeTaken = 0f; // total time taken in successful run
	private float savePointTime = 0f; // cumulative time to get to each save point and the end zone; does not include time beyond save points that resulted in character being killed
	private int numAttempts = 0; // total number of attempts taken
	private string character = "";
	
	private int spawnPoint = -1; // save point that character should spawn at; -1 for beginning location
	private float spawnRot = 0; // rotation of player when spawning
	
	public AudioClip menuSoundtrack;
	public AudioClip arenaSoundtrack;
	public AudioClip buttonClip;
	public AudioClip orbClip;
	public AudioClip leverClip;
	
	public AudioSource audioSource1;
	public AudioSource audioSource2;
	private bool volume = true; // is music/sound on or off?
	
	private bool savePoints = true; // are save points enabled or disabled?
	private bool[] orbsCollected = new bool[6]; // bool for whether each orb has been collected
	
	void Awake()
	{
		DontDestroyOnLoad(transform.gameObject);
		this.LoadStartScreen();
	}
	
    // Start is called before the first frame update
    void Start()
    {
		Array.Fill(this.orbsCollected,false); // at beginning, no orbs have been collected
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	
	public void SetCharacter(string character)
	{
		this.character = character;
	}
	
	public void setScore(int score)
	{
		this.score = score;
	}
	public int getScore()
	{
		return this.score;
	}
	
	public void setTime(float time)
	{
		this.timeTaken = time;
	}
	public float getTime()
	{
		return this.timeTaken;
	}
	public void addSavePointTime(float time)
	{
		this.savePointTime = this.savePointTime + time;
	}
	public void setSavePointTime(float time)
	{
		this.savePointTime = time;
	}
	public float getSavePointTime()
	{
		return this.savePointTime;
	}
	
	public void setSpawnPoint(int spawnPoint)
	{
		this.spawnPoint = spawnPoint;
	}
	public int getSpawnPoint()
	{
		return this.spawnPoint;
	}
	public void setSpawnRotation(float spawnRot)
	{
		this.spawnRot = spawnRot;
	}
	public float getSpawnRotation()
	{
		return this.spawnRot;
	}
	
	public void LoadStartScreen()
	{
		SceneManager.LoadScene("StartScreen");
		
		// reset variables
		this.score = 0;
		this.timeTaken = 0f;
		this.savePointTime = 0f;
		this.numAttempts = 0;
		this.spawnPoint = -1;
		this.spawnRot = 0;
		this.orbsCollected = new bool[6];
		
		// play menu soundtrack
		AudioSource audioSource = this.audioSource1;
		audioSource.clip = menuSoundtrack;
		audioSource.Stop();
		audioSource.loop = true;
		audioSource.Play();
	}
	
	public void StartGame()
	{
		SceneManager.LoadScene("Arena");
		
		// play arena soundtrack
		StartCoroutine(CheckArenaLoaded());
		/*AudioSource audioSource = this.audioSource1;
		audioSource.Stop();
		audioSource.clip = arenaSoundtrack;
		audioSource.loop = true;
		audioSource.Play();*/
	}
	
	public void EndZone()
	{
		SceneManager.LoadScene("EndScreen");
	}
	
	public void incrementAttempts()
	{
		this.numAttempts += 1;
	}
	
	public int getAttempts()
	{
		return this.numAttempts;
	}
	
	public string getChar()
	{
		return this.character;
	}
	
	// play sound effects
	public void PlayButtonClip()
	{
		AudioSource audioSource = this.audioSource2;
		audioSource.Stop();
		audioSource.clip = buttonClip;
		audioSource.loop = false;
		audioSource.Play();
	}	
	public void PlayOrbClip()
	{
		AudioSource audioSource = this.audioSource2;
		audioSource.Stop();
		audioSource.clip = orbClip;
		audioSource.loop = false;
		audioSource.Play();
	}	
	public void PlayLeverClip()
	{
		AudioSource audioSource = this.audioSource2;
		audioSource.Stop();
		audioSource.clip = leverClip;
		audioSource.loop = false;
		audioSource.Play();
	}
	
	// turn music/sound effects on and off
	public bool getVolume()
	{
		return this.volume;
	}
	public void ToggleVolume()
	{
		this.volume = !this.volume;
		
		if(this.volume == false)
		{
			this.audioSource1.volume = 0;
			this.audioSource2.volume = 0;
		}
		else
		{
			this.audioSource1.volume = 1;
			this.audioSource2.volume = 1;
			this.PlayButtonClip();
		}
	}
	
	// enable/disable save points
	public bool getSavePointsEnabled()
	{
		return this.savePoints;
	}
	public void ToggleSavePoints()
	{
		this.savePoints = !this.savePoints;
		this.PlayButtonClip();
	}
	
	// get/set info on which orbs are collected
	public bool getOrbCollected(int id)
	{
		return this.orbsCollected[id];
	}
	public bool[] getOrbsCollected()
	{
		return this.orbsCollected;
	}
	public void setOrbsCollected(bool[] b)
	{
		b.CopyTo(this.orbsCollected,0);
	}
	public void setOrbCollected(int id, bool b)
	{
		this.orbsCollected[id] = b;
	}
	public void addSavePointScore(int num)
	{
		this.score += num;
		//Debug.Log(num.ToString() + " " + this.score.ToString());
	}
	
	IEnumerator CheckArenaLoaded()
	{
		while(true)
		{
			if(SceneManager.GetActiveScene().name == "Arena")
			{
				// play arena soundtrack
				AudioSource audioSource = this.audioSource1;
				audioSource.Stop();
				audioSource.clip = arenaSoundtrack;
				audioSource.loop = true;
				audioSource.Play();
				break;
			}
			else
			{
				yield return null;
			}
		}
	}
}
