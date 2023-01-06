using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// script to spawn character chosen by player with corresponding spawn point
public class ArenaManager : MonoBehaviour
{
	// character prefabs
	public GameObject serazPrefab;
	public GameObject aestaPrefab;
	public GameObject gavaanPrefab;
	public GameObject xaleriePrefab;
	
	private GameManager gameManagerScript;
	private string character;
	
	// start position
	[SerializeField] private float startX;
	[SerializeField] private float startY;
	[SerializeField] private float startZ;
	[SerializeField] private float startRot;
	
	// start location for testing purposes
	[SerializeField] private bool useTestLoc;
	[SerializeField] private float testX;
	[SerializeField] private float testY;
	[SerializeField] private float testZ;
	[SerializeField] private float testRot;
	
	public GameObject[] savePoints = new GameObject[4]; // save point array
	
	public Canvas pauseScreen; // pause screen
	private bool paused = false; // is the game paused?
	
	public int curOrbID = 0; // for instantiating orbs to ensure each has unique ID
	private bool[] orbsCollected = new bool[6]; // which orbs are collected by the player?
	
    // Start is called before the first frame update
    void Start()
    {
		// disable pause screen and make sure scene is not paused
		this.pauseScreen.enabled = false;
		Time.timeScale = 1;
		
		this.gameManagerScript = GameObject.Find("GameManager").GetComponent<GameManager>();
		this.gameManagerScript.getOrbsCollected().CopyTo(this.orbsCollected,0); // restore orb data from save points
		/*for(int i=0; i<this.orbsCollected.Length; i++)
		{
			Debug.Log(this.orbsCollected[i]);
		}*/
		
		Vector3 startLoc = Vector3.zero; // player's starting location
		float yRot = 0; // initial rotation of character
		//Debug.Log("ArenaManager: SpawnPoint " + gameManagerScript.getSpawnPoint().ToString());
		
		// if character has not reached a save point
		if(gameManagerScript.getSpawnPoint() == -1)
		{
			// location that character begins at
			if(useTestLoc)
			{
				startLoc = new Vector3(testX, testY, testZ);
				yRot = startRot;
			}
			else
			{
				startLoc = new Vector3(startX, startY, startZ);
				yRot = testRot;
			}
			
			if(gameManagerScript.getSavePointsEnabled() == false) // if save points are turned off, remove them
			{
				GameObject savePoints = GameObject.Find("SavePoints");
				savePoints.SetActive(false);
			}
		}
		else
		{
			// set start location according to last save point reached and remove all previous save points
			int spawnID = gameManagerScript.getSpawnPoint();
			startLoc = this.savePoints[spawnID].transform.position + Vector3.down*1.995f;
			yRot = gameManagerScript.getSpawnRotation();
			for(int i = 0; i <= spawnID; i++)
			{
				this.savePoints[i].SetActive(false);
			}
		}
		
		// this block should only be executed during testing
		/*var charList = new List<string>{"Gavaan","Xalerie","Seraz","Aesta"};
		int index = Random.Range(0, charList.Count);
		this.character = charList[index];*/
			
        try
		{
			this.gameManagerScript = GameObject.Find("GameManager").GetComponent<GameManager>();
			
			// gets chosen character from game manager
			this.character = gameManagerScript.getChar();
		}
		catch
		{
			// this block should only be executed during testing
			var charList = new List<string>{"Gavaan","Xalerie","Seraz","Aesta"};
			int index = Random.Range(0, charList.Count);
			this.character = charList[index];
		}
		
		// instantiates chosen character at starting location
		switch(this.character)
		{
			case "Seraz":
			{
				Instantiate(serazPrefab, startLoc, Quaternion.Euler(0,yRot,0));
				break;
			}
			case "Aesta":
			{
				Instantiate(aestaPrefab, startLoc, Quaternion.Euler(0,yRot,0));
				break;
			}
			case "Gavaan":
			{
				Instantiate(gavaanPrefab, startLoc, Quaternion.Euler(0,yRot,0));
				break;
			}
			case "Xalerie":
			{
				Instantiate(xaleriePrefab, startLoc, Quaternion.Euler(0,yRot,0));
				break;
			}
			default:
			{
				Instantiate(gavaanPrefab, startLoc, Quaternion.Euler(0,yRot,0));
				break;
			}
		}
    }

    // Update is called once per frame
    void Update()
    {
		// pause/unpause game
        if (Input.GetKeyDown("p"))
        {
			if(this.paused == false)
			{
				Time.timeScale = 0;
				this.pauseScreen.enabled = true;
				this.paused = true;
			}
			else
			{
				Time.timeScale = 1;
				this.pauseScreen.enabled = false;
				this.paused = false;
			}
        }
    }
	
	// resume game after being paused
	public void ResumeButton()
	{
		this.gameManagerScript.PlayButtonClip();
		Time.timeScale = 1;
		this.pauseScreen.enabled = false;
		this.paused = false;
	}
	
	// ensures each orb ID is unique
	public void incrementCurOrbID()
	{
		//Debug.Log(this.curOrbID);
		this.curOrbID++;
	}
	
	// get/set info on which orbs are collected
	public bool[] getOrbsCollected()
	{
		return this.orbsCollected;
	}
	public void setOrbCollected(int id, bool b)
	{
		this.orbsCollected[id] = b;
	}
}
