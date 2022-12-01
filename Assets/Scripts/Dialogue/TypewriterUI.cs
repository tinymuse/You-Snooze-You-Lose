using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TypewriterUI : MonoBehaviour
{
	public float delay;
	
	TMP_Text txt;
	string story;

	void Awake()
	{
		txt = GetComponent<TMP_Text>();
		story = txt.text;
		txt.text = "";

		StartCoroutine("PlayText");
	}

	IEnumerator PlayText()
	{
		foreach (char c in story)
		{
			txt.text += c;
			yield return new WaitForSeconds(delay);
		}
	}

}
