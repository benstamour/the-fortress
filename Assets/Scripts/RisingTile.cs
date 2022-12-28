using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RisingTile : MonoBehaviour
{
    [SerializeField] private int dir;
	[SerializeField] private Vector3 dir0 = Vector3.zero;
	[SerializeField] private Vector3 dir1 = Vector3.zero;
	[SerializeField] private float speed = 2f;
	private Vector3 startPos = Vector3.zero;
	
    // Start is called before the first frame update
    void Start()
    {
		this.startPos = this.gameObject.transform.position;
    }

	// handles movement of tile
    void FixedUpdate()
    {
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
