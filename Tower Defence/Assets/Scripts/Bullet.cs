using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public float health = 3f;
    public float lifeTime = 10f;

    public GameObject pop;

	void Update()
	{
		if(lifeTime <= 0)
		{
			Destroy(gameObject);
		}

		lifeTime--;
	}

	void OnCollisionEnter2D(Collision2D collision)
	{
        if (collision.gameObject.tag == "Enemy")
        {
            Instantiate(pop, transform.position, transform.rotation);
            if(health >= 3)
			{
                health--;
			}
			else
			{
                Destroy(gameObject);
			}
            Destroy(collision.gameObject);
        }
    }
}
