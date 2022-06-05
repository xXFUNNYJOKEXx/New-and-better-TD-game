using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Upgrade : MonoBehaviour
{
    public GameObject upgradesUI;
	public GameObject range;

	void Update()
	{
		if (range.activeInHierarchy == true)
		{
			upgradesUI.SetActive(true);
		}
		else
		{
			upgradesUI.SetActive(false);
		}
	}
}
