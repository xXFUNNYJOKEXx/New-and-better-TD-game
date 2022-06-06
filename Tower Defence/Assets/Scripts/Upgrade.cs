using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Upgrade : MonoBehaviour
{
    public GameObject upgradesUI;
	public GameObject range;
	public GameObject dMonkey;

	[SerializeField] dartMonkey dartMonkeyScript;
	[SerializeField] activatingRangeIndicator activatingRangeIndicatorScript;

	void Update()
	{
		if (dMonkey.tag == "Idle" && range.activeInHierarchy == true)
		{
			upgradesUI.SetActive(true);
		}
		else
		{
			upgradesUI.SetActive(false);
		}
	}

	public void RangeIncrease()
	{
		dartMonkeyScript.range = 4f;
		activatingRangeIndicatorScript.rangeIndicator.transform.localScale = new Vector2(1, 1);
	}
}
