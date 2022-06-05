using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class activatingRangeIndicator : MonoBehaviour
{
	public GameObject rangeIndicator;
	public GameObject DartMonkey;
	bool timeRunOut = false;

	public dartMonkey dartMonkeyScript;

	void Start()
	{
		rangeIndicator.SetActive(false);
	}

	void OnMouseDown()
	{
		if (rangeIndicator.activeInHierarchy == true)
		{
			rangeIndicator.SetActive(false);
		}
		else
		{
			rangeIndicator.SetActive(true);
			StartCoroutine(waitTime());
		}
	}

	private void Update()
	{
		if(Input.GetMouseButtonDown(0) && Input.mousePosition != transform.position && timeRunOut == true)
		{
			rangeIndicator.SetActive(false);
			timeRunOut = false;
		}

		if(DartMonkey.tag == "Buying")
		{
			if (dartMonkeyScript.isOnSomething == true)
			{
				rangeIndicator.SetActive(false);
			}
			else
			{
				rangeIndicator.SetActive(true);
			}
			StartCoroutine(waitTime());
		}
		
	}

	private IEnumerator waitTime()
	{
		yield return new WaitForEndOfFrame();
		timeRunOut = true;
	}
}
