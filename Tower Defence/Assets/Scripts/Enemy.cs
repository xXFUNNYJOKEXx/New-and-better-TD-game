using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 4f;

    private Transform target;
    private int wavepointIndex = 0;

	void Start()
	{
		target = Waypoints.points[0];
	}

	void Update()
	{
		Vector2 dir = target.position - transform.position;
		transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

		if (Vector2.Distance(transform.position, target.position) <= 0.1f)
		{
			GetNextWaypoint();
		}
	}

	void GetNextWaypoint()
	{
		if (wavepointIndex >= Waypoints.points.Length - 1)
		{
			Destroy(gameObject);
			return;
		}

		wavepointIndex++;
		target = Waypoints.points[wavepointIndex];
	}
}
