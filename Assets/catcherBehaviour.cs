using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class catcherBehaviour : MonoBehaviour {

    public GameObject Falling_Hazard;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.name == ("ball_02"))
        {
            Destroy(Falling_Hazard);

        }
    }
}

