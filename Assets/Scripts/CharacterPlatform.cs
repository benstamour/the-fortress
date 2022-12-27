using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// script for when player is on a special object
public class CharacterPlatform : MonoBehaviour
{
	private bool rampTrapTriggered = false; // mini spikeball trap
	
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
			// if the player is located on the circuit tile, lifting platform, or moving floating platforms, the player becomes a child of that object since they should move with it
			if((hit.collider.gameObject.name == "Circuit Tile" || hit.collider.gameObject.name == "Lifting Platform" || hit.collider.gameObject.tag == "BoulderPlatform") && hit.distance <= 1.3)
			{
				gameObject.transform.parent = hit.collider.gameObject.transform;
			}
			// once the player lands on the spikeball ramp, release the mini spikeball trap
			else if(this.rampTrapTriggered == false && hit.collider.gameObject.tag == "Spikeball Ramp")
			{
				gameObject.transform.parent = null;
				GameObject miniSpikeballs = GameObject.Find("Mini Spikeballs");
				foreach(Transform child in miniSpikeballs.transform)
				{
					Rigidbody rb = child.GetComponent<Rigidbody>();
					rb.useGravity = true;
					rb.isKinematic = false;
				}
				this.rampTrapTriggered = true;
			}
			// if the player is not located on any of those, they should not have a parent as they are not moving with any other object
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
