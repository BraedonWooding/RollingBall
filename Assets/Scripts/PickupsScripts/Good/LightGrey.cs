using UnityEngine;
using System.Collections;
//Lowest (15 pts)
public class LightGrey : Pickup
{
	public override void ApplyEffects (Player playerClass)
	{
		playerClass.amountOfPickupsPickedUp++;
		playerClass.score += 15;
		Destroy (this.gameObject);
	}
}