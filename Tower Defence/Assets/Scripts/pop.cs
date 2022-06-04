using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pop : MonoBehaviour
{
	private float countDown = 10f;

	void Update()
	{
		if(countDown < 1)
		{
			countDown += Time.deltaTime;
		}
		else
		{
			Destroy(gameObject);
		}
	}

}
