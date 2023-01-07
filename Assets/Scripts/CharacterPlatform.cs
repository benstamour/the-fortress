using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// script for when player is on a special object
public class CharacterPlatform : MonoBehaviour
{	
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	
	void FixedUpdate()
	{
		RaycastHit hit;
		if(Physics.Raycast(transform.position, transform.TransformDirection(Vector3.down), out hit, Mathf.Infinity))
		{
			// character should follow moving tiles when they are on top of them
			if((hit.collider.gameObject.tag == "RisingTile") && hit.distance <= 0.1)
			{
				gameObject.transform.parent = hit.collider.gameObject.transform;
			}
			// when character enters rising water area, it should trigger the water rising
			else if(hit.collider.gameObject.name == "RisingWaterEnter")
			{
				gameObject.transform.parent = null;
				RisingWater risingWaterScript = GameObject.Find("RisingWaterCube").GetComponent<RisingWater>();
				risingWaterScript.TriggerWater();
				SlidingDoor slidingDoorScript = GameObject.Find("SlidingDoor").GetComponent<SlidingDoor>();
				slidingDoorScript.TriggerDoor();
			}
			// when character lands on trap stepping stone, it should fall
			else if(hit.collider.gameObject.tag == "SteppingStone" && hit.distance <= 0.1)// gameObject.transform.position.y <= -5.4)
			{
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
}
