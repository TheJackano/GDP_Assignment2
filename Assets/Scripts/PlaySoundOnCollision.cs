using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class PlaySoundOnCollision : MonoBehaviour {

    // Use this for initialization
    AudioSource BallBounceFile;

	void Start () {
        BallBounceFile = GetComponent<AudioSource>();
	}
	// Update is called once per frame
	void Update () {
		
	}
    private void OnCollisionEnter(Collision collision)
    {
        BallBounceFile.Play();
    }
}
