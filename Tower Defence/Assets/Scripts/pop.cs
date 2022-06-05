using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pop : MonoBehaviour
{
	private float countDown = 5f;

	void Update()
	{
		if(countDown > 1)
		{
			countDown -= 1;
		}
		else
		{
			Destroy(gameObject);
		}
	}

}
