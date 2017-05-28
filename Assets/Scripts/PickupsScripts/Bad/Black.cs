using UnityEngine;
using System.Collections;

public class Black : Pickup
{
	public override void ApplyEffects (Player playerClass)
	{
		playerClass.amountOfPickupsPickedUp += 2;
		playerClass.score += 200;
		playerClass.stats ["numberOfJumps"] = 0;
		Destroy (this.gameObject);
	}			
}