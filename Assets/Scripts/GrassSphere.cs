using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrassSphere : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Rotate(15*Time.fixedDeltaTime,0,0, Space.World);
    }
}
