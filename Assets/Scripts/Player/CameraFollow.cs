using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
	[SerializeField] private float _smoothSpeed = 0; // The smoothness of camera movement. Adjust as needed.
	[SerializeField] public Vector3 _offset = new Vector3(80.3799973f, 83.2799988f, 2); // Offset of the camera from the target
	private Vector3 velocity = Vector3.zero;
	private Transform _target; // The target object that the camera will follow

	private void Awake()
	{
		_target = FindAnyObjectByType<PlayerController>().transform;
	}

	private void Start()
	{

	}


	void LateUpdate()
	{
		if (_target != null)
		{
			// Calculate the desired position of the camera based on the ship's position and the offset
			Vector3 desiredPosition = _target.position + _offset;

			// Use SmoothDamp to smoothly move the camera towards the desired position
			transform.position = desiredPosition;
		}

	}

}
