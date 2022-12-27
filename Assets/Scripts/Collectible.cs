using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// script for the collectible orbs
public class Collectible : MonoBehaviour
{
	private int rotation = 0;
	private float sum = 0f;
	//private GameManager gameManagerScript;
	
    // Start is called before the first frame update
    void Start()
    {
		//this.gameManagerScript = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	
	void FixedUpdate()
	{
		// handles rotation of the orb; repeats a sequence of two slow rotations followed by two fast rotations
		if(rotation == 0)
		{
			this.transform.parent.Rotate(15*Time.fixedDeltaTime,60*Time.fixedDeltaTime,15*Time.fixedDeltaTime, Space.World);
			this.sum += 60*Time.fixedDeltaTime;
			if(this.sum >= 720)
			{
				rotation = 1;
				this.sum = 0;
			}
		}
		else
		{
			this.transform.parent.Rotate(45*Time.fixedDeltaTime,180*Time.fixedDeltaTime,45*Time.fixedDeltaTime, Space.World);
			this.sum += 180*Time.fixedDeltaTime;
			if(this.sum >= 720)
			{
				rotation = 0;
				this.sum = 0;
			}
		}
		
	}
	
	/*void OnCollisionEnter(Collision col)
	{
		if(col.gameObject.tag == "Character")
		{
			characterScript.IncrementScore();
			this.transform.parent.gameObject.SetActive(false);
		}
	}*/
	
	// when character collides with orbs, add one to their score and set the orb object to inactive
	void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.tag == "Character")
		{
			/*try
			{
				this.gameManagerScript.PlayOrbClip();
			}
			catch
			{
			}*/
			Character characterScript = other.gameObject.GetComponent<Character>();
			characterScript.IncrementScore();
			this.transform.parent.gameObject.SetActive(false);
		}
	}
}
