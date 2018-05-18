using System;
using UnityEngine;

[Serializable]
public struct CameraPositionTarget {
	public Transform position;
	public Transform target;
    public float Duration;
    public float TransitionDuration;

	public Vector3 direction() {
		return (target.position - position.position).normalized;
	}
}