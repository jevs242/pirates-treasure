using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainShip : MonoBehaviour
{
	[SerializeField] private GameObject projectilePrefab;
	[SerializeField] private Transform[] firePoint;
	[SerializeField] private float cannonPower = 100f;
	private bool[] canFire = { true, true, true };


	// Call this method to fire the cannon
	public void FireCannon(int Position)
	{
		GameObject projectile = Instantiate(projectilePrefab, firePoint[Position].position, firePoint[Position].rotation);
		Rigidbody rb = projectile.GetComponent<Rigidbody>();

		// Apply an impulse to the projectile to launch it forward
		rb.AddForce(-firePoint[Position].forward * cannonPower, ForceMode.Impulse);
	}


	public void VerificationFire(int position)
	{
		if (!canFire[position])
			return;

		FireCannon(position);
		canFire[position] = false;
		StartCoroutine(coolDown(position));
	}

	IEnumerator coolDown(int position)
	{
		yield return new WaitForSeconds(2);
		canFire[position] = true;
	}

}
