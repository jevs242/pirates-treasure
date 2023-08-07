using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;
    [SerializeField] private Text _howManyKeysText;
    [SerializeField] private GameObject _pauseCanvas;
	[SerializeField] private GameObject _hudCanvas;
	[SerializeField] private GameObject _beginCanvas;


	private void Awake()
	{
        if(instance == null)
        {
		    instance = this;
        }
	}

	// Start is called before the first frame update
	void Start()
    {
		_beginCanvas.SetActive(true);
        _hudCanvas.SetActive(false);
		Time.timeScale = 0.0f;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
	}

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RefreshKeyText(int keys)
    {
        _howManyKeysText.text = "0" + keys;
    }

    public void SetPause()
    {
        _pauseCanvas.SetActive(!_pauseCanvas.activeSelf);
        _hudCanvas.SetActive(!_pauseCanvas.activeSelf);
        Time.timeScale = !_pauseCanvas.activeSelf ? 1.0f : 0.0f;
		Cursor.visible = _pauseCanvas.activeSelf;
		Cursor.lockState = !_pauseCanvas.activeSelf ? CursorLockMode.Locked : CursorLockMode.None;
	}

    public void QuitGame()
    {
        Application.Quit();
    }

    public void BeginPlay()
    {
		_beginCanvas.SetActive(false);
		_hudCanvas.SetActive(true);
		Time.timeScale = 1.0f;
		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;
	}
}
