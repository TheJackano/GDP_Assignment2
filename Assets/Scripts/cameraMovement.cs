using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct TwoThings
{
    public float f;
    public int i;
}

public class cameraMovement : MonoBehaviour {
    public TwoThings[] Things;
    public GameObject[] LookAt;
    public List<Transform> ObjectTransform;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
