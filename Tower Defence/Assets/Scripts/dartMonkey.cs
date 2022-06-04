using UnityEngine;
using System.Collections;

public class dartMonkey : MonoBehaviour
{
	#region Variables
	private Transform target;
	public Rigidbody2D rb;

	[Header("Attribtes")]

	public float range = 4f;
	public float fireRate = 1f;
	private float fireCountdown = 0f;
	private float speed = 100f;

	[Header("Unity Fields")]

	public string enemyTag = "Enemy";
	public Transform partToRotate;
	public GameObject bulletPrefab;
	public Transform firePoint;
	private Enemy targetEnemy;
	private bool isOnSomething;
	public GameObject redCircle;
	#endregion

	#region CreatingTarget
	// Use this for initialization
	void Start()
	{
		rb = GetComponent<Rigidbody2D>();
		InvokeRepeating("UpdateTarget", 0f, 0.5f);
	}

	//Updates the target everytime the line above repeats.
	void UpdateTarget()
	{
		GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
		float shortestDistance = Mathf.Infinity;
		GameObject nearestEnemy = null;
		
		//Getting closest enemy in range.
		foreach (GameObject enemy in enemies)
		{
			float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
			if (distanceToEnemy < shortestDistance)
			{
				shortestDistance = distanceToEnemy;
				nearestEnemy = enemy;
			}
		}

		if (nearestEnemy != null && shortestDistance <= range)
		{
			target = nearestEnemy.transform;
			targetEnemy = nearestEnemy.GetComponent<Enemy>();
		}
		else
		{
			target = null;
		}

	}
	#endregion

	#region Update
	// Update is called once per frame
	void Update()
	{
		//Makes sure the object being bought does not change rotation or z position.
		if (gameObject.tag == "Buying")
		{
			Vector3 point = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			point.z = 0;
			gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
			transform.position = point;
		}

		//Logic for seeing if object being bought is on something and if so it does something.
		if (Input.GetMouseButtonDown(0) && isOnSomething == false)
		{
			gameObject.tag = "Idle";
			gameObject.layer = LayerMask.NameToLayer("noCollision");
		}

		if(isOnSomething == true)
		{
			redCircle.SetActive(true);
		}
		
		if(isOnSomething == false)
		{
			redCircle.SetActive(false);
		}
		
		//Once bought the obejct will now shoot and be able to target enemies.
		if (gameObject.tag == "Idle")
		{
			if (target == null)
				return;

			Vector3 diff = target.position - transform.position;
			diff.Normalize();

			float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
			partToRotate.rotation = Quaternion.Euler(0f, 0f, rot_z - 90);

			if (fireCountdown <= 0f)
			{
				Shoot();
				fireCountdown = 0.5f / fireRate;
			}

			fireCountdown -= Time.deltaTime;
		}
	}
	#endregion

	#region Methods

	//Code to make the dart or projectile shoot in the direction of the object(eg. dart monkey)
	void Shoot()
	{
		Vector2 direction = target.position - transform.position;
		direction.Normalize();
		GameObject projectile = (GameObject)Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
		projectile.GetComponent<Rigidbody2D>().velocity = direction * speed;
	}

	//Checks collisions(ps. for future self do not change this code as it took a wish and a prayer if you remember) :)
	void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.tag == "Path" || collision.gameObject.tag == "Idle")
		{
			isOnSomething = true;
		}
	}

	private void OnCollisionExit2D(Collision2D collision)
	{
		isOnSomething = false;
	}
	#endregion

	//Draws a red invisible circle
	void OnDrawGizmosSelected()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere(transform.position, range);
	}
}