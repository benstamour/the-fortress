using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// script for spinning laser dragon
public class SpinningDragon : MonoBehaviour
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
		// handles rotation of laser dragon
		this.transform.Rotate(0,0,60*Time.fixedDeltaTime);
	}
}
