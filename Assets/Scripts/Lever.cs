using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : MonoBehaviour
{
    //private InputAction leverAction;
	private bool activated = false;
	
	private Animator anim;
	
	// NearView()
    private float distance;
    private float angleView;
    private Vector3 direction;
	
	private GameManager gameManagerScript;

	// Start is called before the first frame update
	void Start()
    {
		anim = GetComponent<Animator>();
		anim.SetBool("LeverUp", true);
		
		this.gameManagerScript = GameObject.Find("GameManager").GetComponent<GameManager>();
    }
	
	void Update()
    {
		// if the player presses E while near the lever, activate it
        if (Input.GetKeyDown(KeyCode.E) && NearView())
		{
			activate();
		}
    }
	
	public void activate(){
		if (activated == false)
		{
			anim.SetBool("LeverUp", false); // triggers lever animation
			activated = true;
			
			this.gameManagerScript.PlayLeverClip();
			
			StartCoroutine(CheckAnim()); // waits for lever animation to complete before triggering effects

			/*if(gameObject.transform.parent.name == "Lever_Prefab")
			{
				Debug.Log("Lever A");
			}*/
		}
		/*else
		{
			anim.SetBool("LeverUp", true);
			activated = false;

			if(gameObject.transform.parent.name == "Lever_Prefab")
			{
				Debug.Log("Lever B");
			}
		}*/
	}
	
	public bool getActivated()
	{
		return activated;
	}
	
	// is the player close enough to the lever to activate it?
	private bool NearView()
    {
		GameObject character = GameObject.FindWithTag("Character");
        distance = Vector3.Distance(transform.position, character.transform.position);
		if(distance <= 3f)
		{
			return true;
		}
        else
		{
			return false;
		}
    }
	
	IEnumerator CheckAnim()
	{
		// wait for lever animation to complete
		yield return new WaitForSeconds(0.5f);
		while(this.anim.GetCurrentAnimatorStateInfo(0).length >
            this.anim.GetCurrentAnimatorStateInfo(0).normalizedTime)
		{
			yield return null;
		}
		
		// if this lever is for the rising water exit door, slide it
		if(this.gameObject.transform.parent.name == "RisingWaterLever1" || this.gameObject.transform.parent.name == "RisingWaterLever2")
		{
			GameObject slidingDoor = GameObject.Find("SlidingDoor2");
			SlidingDoor slidingDoorScript = slidingDoor.GetComponent<SlidingDoor>();
			if(slidingDoorScript.getNumTriggered() == 0)
			{
				slidingDoorScript.TriggerDoor();
			}
			else
			{
				slidingDoorScript.TriggerDoor2();
			}
		}
		
		// else if this lever is for the cyan lasers, deactivate them
		else if(this.gameObject.transform.parent.name == "CyanLaserLever")
		{
			GameObject cyanLasers = GameObject.Find("CyanLasers");
			cyanLasers.SetActive(false);
		}
		// else if this lever is for the red lasers, deactivate them
		else if(this.gameObject.transform.parent.name == "RedLaserLever")
		{
			GameObject redLasers = GameObject.Find("RedLasers");
			redLasers.SetActive(false);
		}
		// else if this lever is for the yellow lasers, deactivate them
		else if(this.gameObject.transform.parent.name == "YellowLaserLever")
		{
			GameObject redLasers = GameObject.Find("YellowLasers");
			redLasers.SetActive(false);
		}
	}
}
