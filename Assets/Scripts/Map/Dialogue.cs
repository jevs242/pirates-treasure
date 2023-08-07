using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialogue : MonoBehaviour
{
	[Header("Dialogue")]
	[SerializeField, TextArea(4, 6)] private string[] _dialogueLines;
	[SerializeField] private GameObject _dialoguePanel;
	[SerializeField] private Text _dialogueText;
	[SerializeField] private GameObject _chest;
	[SerializeField] private GameObject _endIU;
	[SerializeField] private GameObject _pressSpaceUI;



	private bool _didDialogueStart;
	private int _lineIndex;
	private float _typingTime = 0.05f;
	private bool _end;

	[Header("Player")]
	private bool _isPlayerInRange;

	private void Awake()
	{
	}

	private void Start()
	{
	}

	// Update is called once per frame
	void Update()
	{
		if(!_end)
		{
			_pressSpaceUI.SetActive(_isPlayerInRange);
		}
		else
		{
			_pressSpaceUI.SetActive(false);
		}

		if (PlayerController.instance.howManyKeys != 4)
        {
			if (_isPlayerInRange && Input.GetButtonDown("Jump"))
			{
				RectTransform[] rectChild = _dialoguePanel.GetComponentsInChildren<RectTransform>();
				if (!_didDialogueStart)
				{
					StartDialogue();
				}
				else if (_dialogueText.text == _dialogueLines[_lineIndex])
				{
					NextDialogueLine();

				}
				else
				{
					StopAllCoroutines();
					_dialogueText.text = _dialogueLines[_lineIndex];
				}
			}
        }
		else
		{
			if (_isPlayerInRange && Input.GetButtonDown("Jump") && !_end)
			{
				_end = true;
				_dialogueLines[0] = "Congratulations, you've accomplished it! Your efforts have paid off, and we extend our heartfelt gratitude. Behold, your well-deserved reward awaits you glorious treasure of unimaginable wonders!";
				PlayerController.instance.BeginScene();
				_chest.GetComponent<Animator>().SetTrigger("OpenChest");
				_chest.GetComponent<Animator>().SetTrigger("End");

				RectTransform[] rectChild = _dialoguePanel.GetComponentsInChildren<RectTransform>();
				if (!_didDialogueStart)
				{
					StartDialogue();
				}
				else if (_dialogueText.text == _dialogueLines[_lineIndex])
				{
					NextDialogueLine();

				}
				else
				{
					StopAllCoroutines();
					_dialogueText.text = _dialogueLines[_lineIndex];
				}
				StartCoroutine(BeginTimerForEnd());
			}
		}
	}

	IEnumerator BeginTimerForEnd()
	{
		yield return new WaitForSeconds(14);
		_dialoguePanel.SetActive(false);
		PlayerController.instance.BeginScene();
		StartCoroutine(End());

	}

	IEnumerator End()
	{ 
		yield return new WaitForSeconds(2);
		PlayerController.instance.BeginScene();

		_endIU.SetActive(true);
		Cursor.lockState = CursorLockMode.None;
		Cursor.visible = true;
	}

	private void StartDialogue()
	{
		_didDialogueStart = true;
		_dialoguePanel.SetActive(true);
		_lineIndex = 0;
		StartCoroutine(ShowLine());

	}

	private void NextDialogueLine()
	{

		_lineIndex++;
		if (_lineIndex < _dialogueLines.Length)
		{
			StartCoroutine(ShowLine());
		}
		else
		{
			_didDialogueStart = false;
			_dialoguePanel.SetActive(false);
		}
	}

	private IEnumerator ShowLine()
	{
		_dialogueText.text = string.Empty;

		foreach (char ch in _dialogueLines[_lineIndex])
		{
			_dialogueText.text += ch;
			yield return new WaitForSecondsRealtime(_typingTime);
		}
	}

	private void OnTriggerEnter(Collider collision)
	{
		if (collision.gameObject.CompareTag("Player"))
		{
			_isPlayerInRange = true;
		}
	}

	private void OnTriggerExit(Collider other)
	{
		if (other.gameObject.CompareTag("Player"))
		{
			_isPlayerInRange = false;
		}
	}
}
