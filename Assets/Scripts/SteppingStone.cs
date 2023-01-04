using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SteppingStone : MonoBehaviour
{
	private bool triggered = false;
	[SerializeField] private bool trapTile = true;
	[SerializeField] private Vector3 targetDir = new Vector3(0,-1f,0);
	private Vector3 startPos = Vector3.zero;
	[SerializeField] private float speed = 2f;
	
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
		if(this.triggered)
		{
			this.transform.position = Vector3.MoveTowards(this.transform.position, this.startPos + this.targetDir, speed*Time.deltaTime);
			if((this.transform.position - (this.startPos + this.targetDir)).magnitude <= 0.05)
			{
				this.transform.position = this.startPos + this.targetDir;
			}
		}
	}
	
	public void TriggerFall()
	{
		if(this.trapTile)
		{
			//this.triggered = true;
			Rigidbody rb = gameObject.GetComponent<Rigidbody>();
			rb.isKinematic = false;
			rb.useGravity = true;
		}
	}
}
