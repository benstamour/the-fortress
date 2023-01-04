using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// script to spawn character chosen by player with corresponding spawn point
public class ArenaManager : MonoBehaviour
{
	public GameObject serazPrefab;
	public GameObject aestaPrefab;
	public GameObject gavaanPrefab;
	public GameObject xaleriePrefab;
	private GameManager gameManagerScript;
	private string character;
	[SerializeField] private float startX;
	[SerializeField] private float startY;
	[SerializeField] private float startZ;
	[SerializeField] private float startRot;
	
	[SerializeField] private bool useTestLoc;
	[SerializeField] private float testX;
	[SerializeField] private float testY;
	[SerializeField] private float testZ;
	[SerializeField] private float testRot;
	
	//public Canvas pauseScreen;
	//private bool paused = false;
	
    // Start is called before the first frame update
    void Start()
    {
		// disable pause screen and make sure scene is not paused
		//this.pauseScreen.enabled = false;
		Time.timeScale = 1;
		
		// location that character begins at
		Vector3 startLoc = Vector3.zero;
		float yRot = 0;
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
		
		// this block should only be executed during testing
		var charList = new List<string>{"Gavaan","Xalerie","Seraz","Aesta"};
		int index = Random.Range(0, charList.Count);
		this.character = charList[index];
			
        /*try
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
		}*/
		
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
        /*if (Input.GetKeyDown("p"))
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
        }*/
    }
	
	/*public void ResumeButton()
	{
		this.gameManagerScript.PlayButtonClip();
		Time.timeScale = 1;
		this.pauseScreen.enabled = false;
		this.paused = false;
	}*/
}
