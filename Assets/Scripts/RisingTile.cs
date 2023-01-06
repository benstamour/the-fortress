using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// handles movement of rising tiles in rising water area as well as sweeping lasers
public class RisingTile : MonoBehaviour
{
    [SerializeField] private int dir; // initial direction; can be 0 or 1
	[SerializeField] private Vector3 dir0 = Vector3.zero;
	[SerializeField] private Vector3 dir1 = Vector3.zero;
	[SerializeField] private float speed = 2f;
	private Vector3 startPos = Vector3.zero; // initial location of object
	
    // Start is called before the first frame update
    void Start()
    {
		this.startPos = this.gameObject.transform.position;
    }

	// handles movement of tile
    void FixedUpdate()
    {
		// handles movement of rising tiles
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
