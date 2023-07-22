using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class WaveManager : MonoBehaviour
{
    public static WaveManager instance;

	[SerializeField] private float _amplitude = 1f;
	[SerializeField] private float _lenght = 2f;
	[SerializeField] private float _speed = 1f;
	[SerializeField] private float _offset = 0f;

	private void Awake()
	{
		if(instance == null)
        {
            instance = this;
        }
        else
        {
            Debug.Log("Instance already exists, destroying object!");
            Destroy(this);
        }
	}

	// Start is called before the first frame update
	void Start()
    {
                
    }

    // Update is called once per frame
    void Update()
    {
        _offset += Time.deltaTime * _speed;
    }

    public float GetWaveHeight(float x)
    {
        return _amplitude * Mathf.Sin(x / _lenght + _offset);
    }

    public float length
    {
        get { return _lenght; }
        set { _lenght = value; }
    }

	public float amplitude
	{
		get { return amplitude; }
		set { _amplitude = value; }
	}

	public float speed
	{
		get { return _speed; }
		set { _amplitude = value; }
	}

    public float offset
    {
        get { return _offset; }
        set { _offset = value; }
    }
}
