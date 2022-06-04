using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public Color hoverColour;

    private GameObject tower;

    private SpriteRenderer rend;
    private Color startColour;

	void Start()
	{
		rend = GetComponent<SpriteRenderer>();
		startColour = rend.material.color;
	}

	void OnMouseDown()
	{
		if(tower != null)
		{
			return;
		}

		GameObject towerToBuild = BuildManager.instance.GetTowerToBuild();
		tower = (GameObject)Instantiate(towerToBuild, transform.position, transform.rotation);
	}

	void OnMouseEnter()
	{
		rend.material.color = hoverColour;
	}

	void OnMouseExit()
	{
		rend.material.color = startColour;
	}
}
