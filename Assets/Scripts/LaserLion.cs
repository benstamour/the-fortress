using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lightbug.LaserMachine;

// script for hall of laser lions; this script is attached to the floor of the hall
public class LaserLion : MonoBehaviour
{
	public Material darkMaterial; // when lion is dormant
	public Material brightMaterial; // when lion is shooting lasers or getting ready to shoot lasers
	public GameObject[] lions = new GameObject[5]; // array of all laser lions
	private bool triggered = false; // have the laser lions been triggered?
	private bool inCoroutine = false; // ensures exactly two lions have lasers at any given time
	
	[SerializeField] private float laserWarningTime = 1f; // period between when lion's eyes light up and when they shoot lasers
	[SerializeField] private float laserActivateTime = 2f; // period of time that lion shoots lasers for

    // Start is called before the first frame update
    void Start()
    {
        /*this.lion1 = GameObject.Find("LaserLion1");
		this.lion2 = GameObject.Find("LaserLion2");
		this.lion3 = GameObject.Find("LaserLion3");*/
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	
	
	// when player steps on the floor, laser lions are activated
	void OnCollisionEnter(Collision col)
	{
		if(col.gameObject.tag == "Character")
		{
			this.triggered = true;
		}
	}
	
	void FixedUpdate()
	{
		if(this.triggered == true && this.inCoroutine == false)
		{
			// choose two distinct lions from array to activate lasers
			GameObject[] selected = new GameObject[2];
			
			int rand1 = Random.Range(0,5);
			selected[0] = lions[rand1];
			
			int rand2 = Random.Range(0,5);
			selected[1] = lions[rand2];
			while(rand2 == rand1)
			{
				rand2 = Random.Range(0,5);
				selected[1] = lions[rand2];
			}
			
			/*int rand3 = Random.Range(0,5);
			selected[2] = lions[rand3];
			while(rand3 == rand1 || rand3 == rand2)
			{
				rand3 = Random.Range(0,5);
				selected[2] = lions[rand3];
			}*/
			
			// activate lions
			this.inCoroutine = true;
			StartCoroutine(LionActivate(selected));
		}
	}
	
	/*public void TriggerLions()
	{
		this.triggered = true;
	}*/
	
	IEnumerator LionActivate(GameObject[] selected)
	{
		// light up selected lions' eyes for warning time
		for(int i = 0; i < selected.Length; i++)
		{
			GameObject lion = selected[i];
			GameObject leftEye = lion.transform.Find("LeftEye").gameObject;
			GameObject rightEye = lion.transform.Find("RightEye").gameObject;
			leftEye.GetComponent<MeshRenderer>().material = brightMaterial;
			rightEye.GetComponent<MeshRenderer>().material = brightMaterial;
		}
		yield return new WaitForSeconds(this.laserWarningTime);
		
		// lions shoot lasers for activated time
		for(int i = 0; i < selected.Length; i++)
		{
			GameObject lion = selected[i];
			GameObject leftLaser = lion.transform.Find("Laser_LeftEye").gameObject;
			GameObject rightLaser = lion.transform.Find("Laser_RightEye").gameObject;
			leftLaser.GetComponent<LaserMachine>().enabled = true;
			rightLaser.GetComponent<LaserMachine>().enabled = true;
		}
		yield return new WaitForSeconds(this.laserActivateTime);
		
		// deactivate lasers
		for(int i = 0; i < selected.Length; i++)
		{
			GameObject lion = selected[i];
			GameObject leftEye = lion.transform.Find("LeftEye").gameObject;
			GameObject rightEye = lion.transform.Find("RightEye").gameObject;
			GameObject leftLaser = lion.transform.Find("Laser_LeftEye").gameObject;
			GameObject rightLaser = lion.transform.Find("Laser_RightEye").gameObject;
			leftEye.GetComponent<MeshRenderer>().material = darkMaterial;
			rightEye.GetComponent<MeshRenderer>().material = darkMaterial;
			leftLaser.GetComponent<LaserMachine>().RemoveLasers();
			rightLaser.GetComponent<LaserMachine>().RemoveLasers();
			leftLaser.GetComponent<LaserMachine>().enabled = false;
			rightLaser.GetComponent<LaserMachine>().enabled = false;
			Destroy(leftLaser.transform.Find("lineRenderer_0").gameObject);
			Destroy(rightLaser.transform.Find("lineRenderer_0").gameObject);
		}
		this.inCoroutine = false; // ready for next set of lions to activate
	}
}
