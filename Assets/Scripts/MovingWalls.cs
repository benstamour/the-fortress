using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// script for sliding spiked walls
public class MovingWalls : MonoBehaviour
{
	[SerializeField] private int dir;
	private Vector3 startPos = Vector3.zero;
	private Vector3 dir0 = Vector3.zero;
	private Vector3 dir1 = Vector3.zero;
	[SerializeField] private float speed = 2f;
	
    // Start is called before the first frame update
    void Start()
    {
        this.dir0 = new Vector3(-6, 0, 0);
		this.dir1 = new Vector3(6, 0, 0);
		this.startPos = this.gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
		// handles movement of spiked walls
        if(this.dir == 0)
		{
			this.transform.position = Vector3.MoveTowards(this.transform.position, this.startPos + this.dir0, speed*Time.deltaTime);
			if((this.transform.position - (this.startPos + this.dir0)).magnitude <= 0.05)
			{
				this.transform.position = this.startPos + this.dir0;
			}
			if(this.transform.position == this.startPos + this.dir0)
			{
				this.dir = 1;
				this.startPos = this.transform.position;
			}
		}
		else
		{
			this.transform.position = Vector3.MoveTowards(this.transform.position, this.startPos + this.dir1, speed*Time.deltaTime);
			if((this.transform.position - (this.startPos + this.dir1)).magnitude <= 0.05)
			{
				this.transform.position = this.startPos + this.dir1;
			}
			if(this.transform.position == this.startPos + this.dir1)
			{
				this.dir = 0;
				this.startPos = this.transform.position;
			}
		}
    }
}
