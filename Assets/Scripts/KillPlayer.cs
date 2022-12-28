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
	
	void Respawn()
	{
		SceneManager.LoadScene("Arena");
	}

	// when player gets killed, reload the level
    void OnCollisionEnter(Collision col)
    {
		if(col.gameObject.tag == "DeathZone")
		{
			//Debug.Log("A");
			Respawn();
		}
    }
	
	public void LaserHit()
	{
		//Debug.Log("B");
		Respawn();
	}
}
