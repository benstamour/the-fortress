using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// script that stores game data so that it is saved if a new scene loads or if the current scene reloads
public class GameManager : MonoBehaviour
{
	private int score = 0;
	private float timeTaken = 0f;
	private int numAttempts = 0;
	private string character = "";
	
	private int spawnPoint = -1;
	private float spawnRot = 0;
	
	/*public AudioClip menuSoundtrack;
	public AudioClip arenaSoundtrack;
	public AudioClip buttonClip;
	public AudioClip orbClip;
	public AudioClip leverClip;
	
	public AudioSource audioSource1;
	public AudioSource audioSource2;
	private bool volume = true; // is music/sound on or off?*/
	
	void Awake()
	{
		DontDestroyOnLoad(transform.gameObject);
		//this.LoadStartScreen();
	}
	
    // Start is called before the first frame update
    void Start()
    {
		
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
	
	/*public void LoadStartScreen()
	{
		SceneManager.LoadScene("StartScreen");
		
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
		AudioSource audioSource = this.audioSource1;
		audioSource.Stop();
		audioSource.clip = arenaSoundtrack;
		audioSource.loop = true;
		audioSource.Play();
	}*/
	
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
	/*public void PlayButtonClip()
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
		}
	}*/
}
