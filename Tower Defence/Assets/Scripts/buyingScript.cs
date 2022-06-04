using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buyingScript : MonoBehaviour
{
    public GameObject objectBought;

	public void BuyingObject()
	{
		Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		mousePos.z = 0;
		Instantiate(objectBought, mousePos, Quaternion.identity);
		objectBought.tag = "Buying";
	}
}
