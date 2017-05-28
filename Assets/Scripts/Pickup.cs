using UnityEngine;
using System.Collections;

public class Pickup : MonoBehaviour
{

	public virtual void Update ()
	{
		transform.Rotate (new Vector3 (15, 30, 45) * Time.deltaTime);
	}

	public virtual void ApplyEffects (Player playerClass)
	{
		//Apply Pickup Effects + Destroy if needed
	}
}