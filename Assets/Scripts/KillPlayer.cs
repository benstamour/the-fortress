using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// script when player gets killed
public class KillPlayer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
	
	public void Respawn()
	{
		SceneManager.LoadScene("Arena");
	}

	// when player gets killed, reload the level
    void OnCollisionEnter(Collision col)
    {
		if(col.gameObject.tag == "DeathZone")
		{
			Respawn();
		}
    }
	
	// when player gets killed, reload the level
    void OnTriggerEnter(Collider other)
    {
		if(other.gameObject.tag == "DeathZone")
		{
			Respawn();
		}
    }
	
	public void LaserHit()
	{
		Respawn();
	}
}
