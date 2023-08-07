using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    [SerializeField]private AudioClip[] _audioClips; 
    [SerializeField]private AudioSource _audioSource;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlaySFX(int clips)
    {
        _audioSource.clip = _audioClips[clips];
        _audioSource.Play();
    }

	public void SoundDelayI(int clips, float delay)
	{
		StartCoroutine(SoundDelay(clips, delay));
	}

	private IEnumerator SoundDelay(int clips , float delay)
	{
		yield return new WaitForSeconds(delay);
		AudioManager.instance.PlaySFX(clips);

	}
}
