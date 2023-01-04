using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathZone : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	
	// when player gets killed, reload the level
    void OnCollisionEnter(Collision col)
    {
		if(col.gameObject.tag == "Character")
		{
			KillPlayer killScript = col.gameObject.GetComponent<KillPlayer>();
			killScript.Respawn();
		}
    }
}
