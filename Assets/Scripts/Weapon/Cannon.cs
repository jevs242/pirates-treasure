using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Cannon : MonoBehaviour
{
	// Start is called before the first frame update
	void Start()
    {
        Destroy(gameObject , 5);
    }

	private void Update()
	{
		transform.position = new Vector3(transform.position.x , Physics.gravity.y * Time.deltaTime + transform.position.y , transform.position.z);
	}

	private void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.CompareTag("Enemy"))
		{
			Destroy(other.gameObject);
			Destroy(gameObject);
		}
	}

}
