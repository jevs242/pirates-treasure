using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Floater : MonoBehaviour
{
    private Rigidbody _rb;
    [SerializeField] private float _depthBeforeSubmerged = 1f;
    [SerializeField] private float _displacementAmount = 3f;
	[SerializeField] private int floaterCount = 1;
	[SerializeField] private float waterDrag = 0.99f;
	[SerializeField] private float waterAngularDrag = 0.5f;

	private void Awake()
	{
		_rb = gameObject.GetComponentInParent<Rigidbody>();
	}

	private void FixedUpdate()
	{
		_rb.AddForceAtPosition(Physics.gravity / floaterCount, transform.position, ForceMode.Acceleration);
		float waveHeight = WaveManager.instance.GetWaveHeight(transform.position.x);
		if(transform.position.y < waveHeight)
		{
			float displacemntMultiplier = Mathf.Clamp01((waveHeight - transform.position.y) / _depthBeforeSubmerged) * _displacementAmount;
			_rb.AddForceAtPosition(new Vector3(0f, Mathf.Abs(Physics.gravity.y) * displacemntMultiplier , 0f) , transform.position , ForceMode.Acceleration);
			_rb.AddForce(displacemntMultiplier * -_rb.velocity * waterDrag * Time.fixedDeltaTime, ForceMode.VelocityChange);
			_rb.AddTorque(displacemntMultiplier * -_rb.angularVelocity * waterAngularDrag * Time.fixedDeltaTime, ForceMode.VelocityChange);
		}
	}
}
