using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	public static PlayerController instance;
	[SerializeField] private float _speed = 1;
	[SerializeField] private float _speedLeft = 1;
	private MainShip _mainShip;
	private Rigidbody _rb;
	[SerializeField] private int _howManyKeys;
	private Vector3 _checkpoint;
	private bool _inScene;


	private void Awake()
	{
		_mainShip = gameObject.GetComponent<MainShip>();
		_rb = gameObject.GetComponent<Rigidbody>();
		instance = this;
	}

	// Start is called before the first frame update
	void Start()
	{

		//Cursor.visible = false;
		//Cursor.lockState = CursorLockMode.Locked;
	}

	// Update is called once per frame
	void Update()
	{
		if (!_inScene)
		{
			float spin = Input.GetAxis("Horizontal") * _speedLeft * Time.deltaTime;
			float forward = Input.GetAxis("Vertical");

			// Rotate the character on the Y axis
			transform.Rotate(0, spin, 0);
			// Obtain vertical input (for forward movement)

			if (forward > 0)
			{
				Vector3 forwardForce = new();
				if (_rb.velocity.magnitude == 0)
				{
					forwardForce = -transform.forward * _speed  * forward * Time.deltaTime;
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

			if(Input.GetKeyDown(KeyCode.Escape))
			{
				UIManager.instance.SetPause();
			}
		}

	}

	IEnumerator Respawn()
	{
		yield return new WaitForSeconds(3);
		transform.position = _checkpoint;
	}

	public void BeginScene()
	{
		StartCoroutine(SceneDelay());
	}

	private void OnCollisionEnter(Collision collision)
	{
		if (!collision.gameObject.CompareTag("Water"))
			AudioManager.instance.PlaySFX(3);
	}

	public IEnumerator SceneDelay()
	{
		_inScene = true;
		_rb.velocity = Vector3.zero;
		yield return new WaitForSeconds(3);
		_inScene = false;

	}

	public int howManyKeys
	{
		get { return _howManyKeys; }
		set { _howManyKeys = value; }
	}

	public Vector3 checkpoint
	{
		get { return _checkpoint; }
		set { _checkpoint = value; }
	}

	public bool inScene
	{
		get { return _inScene; }
		set { _inScene = value; }
	}
}
