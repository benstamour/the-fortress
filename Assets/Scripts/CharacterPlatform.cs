using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// script for when player is on a special object
public class CharacterPlatform : MonoBehaviour
{
	//private Character characterScript;
	//private bool onSphere = false;
	
    // Start is called before the first frame update
    void Start()
    {
        //characterScript = gameObject.GetComponent<Character>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	
	void FixedUpdate()
	{
		RaycastHit hit;
		/*if((Physics.Raycast(transform.position, transform.TransformDirection(Vector3.down), out hit, Mathf.Infinity) && hit.collider.gameObject.tag == "GrassSphere") || (Physics.Raycast(transform.position + new Vector3(0.25f,0,0), transform.TransformDirection(Vector3.down), out hit, Mathf.Infinity) && hit.collider.gameObject.tag == "GrassSphere") || (Physics.Raycast(transform.position + new Vector3(-0.25f,0,0), transform.TransformDirection(Vector3.down), out hit, Mathf.Infinity) && hit.collider.gameObject.tag == "GrassSphere") || (Physics.Raycast(transform.position + new Vector3(0,0,0.25f), transform.TransformDirection(Vector3.down), out hit, Mathf.Infinity) && hit.collider.gameObject.tag == "GrassSphere") || (Physics.Raycast(transform.position + new Vector3(0,0,-0.25f), transform.TransformDirection(Vector3.down), out hit, Mathf.Infinity) && hit.collider.gameObject.tag == "GrassSphere"))
		//if(Physics.Raycast(transform.position, transform.TransformDirection(Vector3.down), out hit, Mathf.Infinity) && hit.collider.gameObject.tag == "GrassSphere" && hit.distance <= 0.5 && this.onSphere == false)
		{
			if(hit.distance <= 0.5)
			{
				this.onSphere = true;
				StartCoroutine(OnSphere());
			}
		}*/
		if(Physics.Raycast(transform.position, transform.TransformDirection(Vector3.down), out hit, Mathf.Infinity))
		{
			if((hit.collider.gameObject.tag == "RisingTile") && hit.distance <= 0.1)
			{
				//Debug.Log("A");
				gameObject.transform.parent = hit.collider.gameObject.transform;
			}
			else if(hit.collider.gameObject.name == "RisingWaterEnter")
			{
				gameObject.transform.parent = null;
				RisingWater risingWaterScript = GameObject.Find("RisingWaterCube").GetComponent<RisingWater>();
				//SpikedWall crusherWallScript = GameObject.Find("CrusherWall").GetComponent<SpikedWall>();
				//SpikedWall wallSpikesScript = GameObject.Find("WallSpikes").GetComponent<SpikedWall>();
				risingWaterScript.TriggerWater();
				//crusherWallScript.TriggerCrusher();
				//wallSpikesScript.TriggerCrusher();
				SlidingDoor slidingDoorScript = GameObject.Find("SlidingDoor").GetComponent<SlidingDoor>();
				slidingDoorScript.TriggerDoor();
			}
			else if(hit.collider.gameObject.tag == "SteppingStone" && hit.distance <= 0.1)// gameObject.transform.position.y <= -5.4)
			{
				//Debug.Log(hit.distance);
				gameObject.transform.parent = null;//hit.collider.gameObject.transform;
				SteppingStone steppingStoneScript = hit.collider.gameObject.GetComponent<SteppingStone>();
				steppingStoneScript.TriggerFall();
				
			}
			else
			{
				gameObject.transform.parent = null;
			}
		}
		else
		{
			gameObject.transform.parent = null;
		}
	}
	
	/*void OnCollisionEnter(Collision col)
    {
		if(this.onSphere && col.gameObject.tag != "GrassSphere")
		{
			this.onSphere = false;
		}
    }
	
	
	IEnumerator OnSphere()
	{
		while(this.onSphere)
		{
			if(characterScript.getJumping())
			{
				this.onSphere = false;
			}
			if(this.onSphere == true)
			{
				gameObject.transform.position = Vector3.MoveTowards(this.transform.position, this.transform.position + new Vector3(0,0,1), 10f*Time.deltaTime);
				yield return null;
			}
			else
			{
				break;
			}
		}
	}*/
}
