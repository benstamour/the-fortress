using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlidingDoor : MonoBehaviour
{
	[SerializeField] private float speed = 2f;
	[SerializeField] private Vector3 targetDir;
	private Vector3 startPos = Vector3.zero;
	private bool doorTriggered = false;
	
	private bool doorTriggered2 = false; // for second sliding door
	private int numTriggered = 0;
	
    // Start is called before the first frame update
    void Start()
    {
        this.startPos = this.gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	
	void FixedUpdate()
	{
		if(this.doorTriggered)
		{
			this.transform.position = Vector3.MoveTowards(this.transform.position, this.startPos + this.targetDir, speed*Time.deltaTime);
			if((this.transform.position - (this.startPos + this.targetDir)).magnitude <= 0.05)
			{
				this.transform.position = this.startPos + this.targetDir;
				this.numTriggered++;
			}
		}
		if(this.doorTriggered2)
		{
			this.transform.position = Vector3.MoveTowards(this.transform.position, this.startPos + this.targetDir, speed*Time.deltaTime);
			if((this.transform.position - (this.startPos + this.targetDir)).magnitude <= 0.05)
			{
				this.transform.position = this.startPos + this.targetDir;
				this.gameObject.SetActive(false);
				this.numTriggered++;
			}
		}
	}
	
	public void TriggerDoor()
	{
		this.doorTriggered = true;
	}
	public void TriggerDoor2() // for second sliding door
	{
		this.doorTriggered2 = true;
		this.startPos = this.gameObject.transform.position;
	}
	
	public int getNumTriggered()
	{
		return numTriggered;
	}
}
