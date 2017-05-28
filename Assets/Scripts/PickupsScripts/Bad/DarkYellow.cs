using UnityEngine;
using System.Collections;
//Second Highest (-100 pts + Speed --)
public class DarkYellow : Pickup
{
	public override void ApplyEffects (Player playerClass)
	{
		playerClass.amountOfPickupsPickedUp += 2;
		playerClass.score += 100;
		playerClass.stats ["speed"] -= 5;
		Destroy (this.gameObject);
	}		
}