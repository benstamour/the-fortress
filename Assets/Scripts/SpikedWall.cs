using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikedWall : MonoBehaviour
{
	[SerializeField] private float speed = 2f;
	private Vector3 startScale = Vector3.zero;
	private Vector3 targetScale = Vector3.zero;
	[SerializeField] private float increase;
	[SerializeField] private Vector3 targetDir;
	private bool crusherTriggered = false;
	private Vector3 startPos = Vector3.zero;
	
    // Start is called before the first frame update
    void Start()
    {
        this.startPos = this.gameObject.transform.position;
		this.startScale = this.gameObject.transform.localScale;
		this.targetScale = new Vector3(this.startScale.x + increase, this.startScale.y, this.startScale.z);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	
	void FixedUpdate()
    {
		if(crusherTriggered)
		{
			if(gameObject.name == "CrusherWall")
			{
				Vector3 curScale = this.gameObject.transform.localScale;
				this.transform.localScale = new Vector3(curScale.x + (increase*speed*Time.deltaTime), this.startScale.y, this.startScale.z);
				if((curScale - this.targetScale).magnitude <= 0.05)
				{
					this.transform.localScale = this.targetScale;
				}
			}
			else
			{
				this.transform.position = Vector3.MoveTowards(this.transform.position, this.startPos + this.targetDir, speed*Time.deltaTime);
				if((this.transform.position - (this.startPos + this.targetDir)).magnitude <= 0.05)
				{
					this.transform.position = this.startPos + this.targetDir;
				}
			}
		}
    }
	
	public void TriggerCrusher()
	{
		this.crusherTriggered = true;
	}
}
