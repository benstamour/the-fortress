using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RisingWater : MonoBehaviour
{
	[SerializeField] private float speed = 2f;
	private Vector3 startScale = Vector3.zero;
	private Vector3 targetScale = Vector3.zero;
	[SerializeField] private float increase;
	private bool waterTriggered = false;
	
    // Start is called before the first frame update
    void Start()
    {
        this.startScale = this.gameObject.transform.localScale;
		this.targetScale = new Vector3(this.startScale.x, this.startScale.y + increase, this.startScale.z);
    }

    void FixedUpdate()
    {
		if(this.waterTriggered)
		{
			Vector3 curScale = this.gameObject.transform.localScale;
			this.transform.localScale = new Vector3(this.startScale.x, curScale.y + (increase*speed*Time.deltaTime), this.startScale.z);
			if((curScale - this.targetScale).magnitude <= 0.05)
			{
				this.transform.localScale = this.targetScale;
			}
		}
    }
	
	public void TriggerWater()
	{
		this.waterTriggered = true;
	}
}
