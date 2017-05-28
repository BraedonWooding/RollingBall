using UnityEngine;
using System.Collections;
//Second Lowest (25 pts + Jump Height ++)
public class Blue : Pickup
{
	public override void ApplyEffects (Player playerClass)
	{
		playerClass.amountOfPickupsPickedUp++;
		playerClass.score += 25;
		playerClass.stats ["jumpHeight"] += 20;
		Destroy (this.gameObject);
	}			
}