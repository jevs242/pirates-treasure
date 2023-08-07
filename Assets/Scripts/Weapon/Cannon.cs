using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Cannon : MonoBehaviour
{
	[SerializeField] private GameObject _fbxShipExplotion;
	[SerializeField] private GameObject _fbxRockExplotion;


	// Start is called before the first frame update
	void Start()
    {
		AudioManager.instance.PlaySFX(1);
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
			Instantiate(_fbxShipExplotion, other.gameObject.transform.position + new Vector3(0 , 30 , 0) , transform.rotation);
			Destroy(other.gameObject);
			Destroy(gameObject);
		}

		if (other.gameObject.CompareTag("Rock"))
		{
			Instantiate(_fbxRockExplotion, gameObject.transform.transform.position, transform.rotation);
			AudioManager.instance.PlaySFX(0);
			Destroy(other.gameObject);
			Destroy(gameObject);

		}
	}

}
