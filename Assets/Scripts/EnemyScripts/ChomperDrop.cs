using UnityEngine;
using System.Collections;

public class ChomperDrop : Enemy
{

	public Vector3 StartPos;
	public float step;
	public float timer = 2;
	public Vector3 ground;
	bool moveUp;
	bool moveDown;

	public ChomperDrop ()
	{
		speed = 5;
		damage = 1;
		hitPoints = 1000;
	}

	void Start ()
	{
		StartPos = transform.position;
		RaycastHit hit;
		if (Physics.Raycast (transform.position, -Vector3.up, out hit, Mathf.Infinity)) {
			ground = hit.point;
		}
	}

	void Update ()
	{
		step = speed * Time.deltaTime;
		timer -= Time.deltaTime;
		if (timer <= 0) {
			if (moveDown) {
				transform.position = Vector3.MoveTowards (transform.position, ground, step);
			} else if (moveUp) {
				transform.position = Vector3.MoveTowards (transform.position, StartPos, step);
			}
			if (Mathf.Approximately (transform.position.y, StartPos.y)) {
				moveUp = false;
				moveDown = true;
				timer = 2;
			}

		}
	}

	void OnCollisionEnter (Collision col)
	{
		moveUp = true;
		moveDown = false;
		timer = 2;
	}
}