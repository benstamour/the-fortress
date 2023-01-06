using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// script to distribute orbs in arena upon loading; used to assign an orb colour to each character
public class AddOrbs : MonoBehaviour
{
	private GameManager gameManagerScript;
	public GameObject orbPrefab; // orb prefab
	
	GameObject[] orbs = new GameObject[6];
	
    // Start is called before the first frame update
    void Start()
    {
		this.gameManagerScript = GameObject.Find("GameManager").GetComponent<GameManager>();
		
		// instantiate orbs
		this.orbs[0] = Instantiate(orbPrefab, new Vector3(0f, 3f, 23f), Quaternion.identity);
		this.orbs[1] = Instantiate(orbPrefab, new Vector3(29f, 6.5f, 61f), Quaternion.identity);
		this.orbs[2] = Instantiate(orbPrefab, new Vector3(-5.5f, 2f, 48f), Quaternion.identity);
		this.orbs[3] = Instantiate(orbPrefab, new Vector3(22f, -3f, 17.75f), Quaternion.identity);
		this.orbs[4] = Instantiate(orbPrefab, new Vector3(55.5f, -3f, 14f), Quaternion.identity);
		this.orbs[5] = Instantiate(orbPrefab, new Vector3(75.5f, -1f, -4f), Quaternion.identity);
		
		/*for(int i = 0; i < orbs.Length; i++)
		{
			if(this.gameManagerScript.getOrbCollected(i))
			{
				Debug.Log(i.ToString() + " true");
				this.orbs[i].SetActive(false);
			}
			else
			{
				Debug.Log(i.ToString() + " false");
				this.orbs[i].GetComponent<Collectible>().setID(i);
			}
		}*/
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}