using System;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour {
	// a list of position/target combinations - edit this in the inspector
	public List<CameraPositionTarget> CameraPlaces;

	// timer for staying and transitioning
	private float _stayTimer;
	private float _transitionTimer;
	// are we currently transitioning?
	private bool _isTransitioning = false;
	// indices of current and previous viewpoints
	private int _currentIndex = 0;
	private int _previousIndex = 0;
    private CameraPositionTarget CurrentCamTarget;

    private bool finished = false;

	void Start() {
		Debug.Assert(CameraPlaces.Count > 0);

		// go to start position and rotation
		transform.position = CameraPlaces[0].position.position;
		transform.LookAt(CameraPlaces[0].target.position);

		// initialize timers
		_stayTimer = CameraPlaces[0].Duration;
		_transitionTimer = CameraPlaces[0].TransitionDuration;
        CurrentCamTarget = CameraPlaces[0];
	}

	void Update () {
		Debug.Assert(CameraPlaces.Count > 0);

        if (finished) return;

        if ( _isTransitioning ) {
			// update the transition timer
			_transitionTimer -= Time.deltaTime;

			// calculate the new position and rotation smoothly interpolated
			var curr = getPrevTarget();
			var next = getCurrentTarget();
			// 0...1 value over the transition time
			float t = 1.0f - (_transitionTimer / curr.TransitionDuration);
			// position and rotation update based on current and previous views
			transform.position = smoothstepVec3(curr.position.position, next.position.position, t);
            transform.rotation = Quaternion.LookRotation(smoothstepVec3(curr.direction(), next.direction(), t));
            // check whether we need to change state and reset the timer
            if (_transitionTimer < 0.0f) {
				_transitionTimer = curr.TransitionDuration;
				_isTransitioning = false;
			}
		} else {
			// update the stay timer
			_stayTimer -= Time.deltaTime;

			// check whether we need to change state and reset the timer
			if (_stayTimer < 0.0f) {
				_isTransitioning = true;
				_previousIndex = _currentIndex;
                _currentIndex = (_currentIndex + 1);

                if (_currentIndex >= CameraPlaces.Count)
                {
                    finished = true;
                }
                else
                {
                    CurrentCamTarget = CameraPlaces[_currentIndex];
                    _stayTimer = CurrentCamTarget.Duration;
                }

			}

            // just stay; don't do anything

		}
	}

	CameraPositionTarget getCurrentTarget() {
		return CameraPlaces[_currentIndex];
	}

	CameraPositionTarget getPrevTarget() {
		return CameraPlaces[_previousIndex];
	}

	// this is how to smoothy interpolate between two vectors using a smoothstep curve
	Vector3 smoothstepVec3(Vector3 a, Vector3 b, float t ) {
		t = Mathf.Clamp01(t); // don't go beyond bounds
		return new Vector3(Mathf.SmoothStep(a.x, b.x, t), Mathf.SmoothStep(a.y, b.y, t), Mathf.SmoothStep(a.z, b.z, t));
	}
}
