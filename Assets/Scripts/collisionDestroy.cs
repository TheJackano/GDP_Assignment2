﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collisionDestroy : MonoBehaviour {

    public GameObject ball;
    public GameObject[] toBeDestroyed;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject == ball)
        {
            foreach (GameObject GO in toBeDestroyed)
            {
                Destroy(GO);
            }
        }
    }
}
