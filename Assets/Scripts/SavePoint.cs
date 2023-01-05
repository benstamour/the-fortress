using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavePoint : MonoBehaviour
{
	[SerializeField] private int id;
	[SerializeField] private float yRot;
	
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	
	// when character collides with save point, set new spawn point
	void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.tag == "Character")
		{
			/*try
			{
				this.gameManagerScript.PlayOrbClip();
			}
			catch
			{
			}*/
			Debug.Log("SavePoint " + this.id.ToString() + " " + this.yRot.ToString());
			GameManager gameManagerScript = GameObject.Find("GameManager").GetComponent<GameManager>();
			gameManagerScript.setSpawnPoint(this.id);
			gameManagerScript.setSpawnRotation(this.yRot);
			this.transform.parent.gameObject.SetActive(false);
		}
	}
}
