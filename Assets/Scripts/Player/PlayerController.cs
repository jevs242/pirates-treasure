using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	[SerializeField] private float _speed = 1;
	[SerializeField] private float _speedLeft = 1;
	private MainShip _mainShip;
	private Rigidbody _rb;

	private void Awake()
	{
		_mainShip = gameObject.GetComponent<MainShip>();
		_rb = gameObject.GetComponent<Rigidbody>();
	}

	// Start is called before the first frame update
	void Start()
	{
		Cursor.visible = false;
		Cursor.lockState = CursorLockMode.Locked;
	}

	// Update is called once per frame
	void Update()
	{
		float spin = Input.GetAxis("Horizontal") * _speedLeft * Time.deltaTime;
		float forward = Input.GetAxis("Vertical");

		// Rotate the character on the Y axis
		if (VerificationTwoKeys(KeyCode.W))
			transform.Rotate(0, spin, 0);
		// Obtain vertical input (for forward movement)

		if (forward > 0)
		{
			Vector3 forwardForce = new();
			if (_rb.velocity.magnitude == 0)
			{
				forwardForce = -transform.forward * _speed / 4 * forward * Time.deltaTime;
			}
			else
			{
				forwardForce = -transform.forward * _speed * forward * Time.deltaTime;

			}

			_rb.AddForce(forwardForce, ForceMode.VelocityChange);
			if (transform.position.y > -5)
			{
				transform.position = new Vector3(transform.position.x, -5, transform.position.z);
			}
		}

		if (Input.GetButtonDown("Fire1"))
		{
			_mainShip.VerificationFire(0);
		}


		if (Input.GetButtonDown("Fire2"))
		{
			_mainShip.VerificationFire(1);
		}


		if (Input.GetButtonDown("Fire3"))
		{
			_mainShip.VerificationFire(2);
		}
	}

	bool VerificationTwoKeys(KeyCode keyCode)
	{
		return Input.GetKey(keyCode) && Input.GetKey(KeyCode.A) || Input.GetKey(keyCode) && Input.GetKey(KeyCode.D);
	}


}
