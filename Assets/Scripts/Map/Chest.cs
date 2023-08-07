using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
	[SerializeField] private Transform _checkpoint;
    private Animator _animation;

	private void Awake()
	{
		_animation = GetComponent<Animator>();
	}

	private void OnTriggerEnter(Collider other)
	{
		if(other.CompareTag("Player"))
        {
			PlayerController player = other.GetComponent<PlayerController>();
            player.howManyKeys++;
			_animation.SetTrigger("OpenChest");
			AudioManager.instance.SoundDelayI(2, 3);
            player.checkpoint = _checkpoint.position;
			UIManager.instance.RefreshKeyText(player.howManyKeys);
			player.BeginScene();
            Destroy(this);
        }    
	}


}
