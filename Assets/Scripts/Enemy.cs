using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour
{
	public float hitPoints; //If Invincible Set to 1000.
	public float damage; //If no damage set to 0; Healing set to negative values.
	public float speed; //If no speed set to 0.

	public Enemy ()
	{

	}

	public virtual void ApplyEffects (Player playerClass)
	{
		playerClass.stats ["hitPoints"] -= damage;
		playerClass.invincible = true;
	}

	public virtual void ApplyDamage (float incomingDamage)
	{
		hitPoints -= incomingDamage;
		if (hitPoints <= 0) {
			//Play Destroy Animation
			Destroy (this);
		}
	}
}