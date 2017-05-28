using UnityEngine;
using System.Collections;
//Highest (-  200 pts + Damage --)
public class DarkRed : Pickup
{
	public override void ApplyEffects (Player playerClass)
	{
		playerClass.amountOfPickupsPickedUp += 2;
		playerClass.score += 200;
		playerClass.stats ["damage"] -= 1;
		Destroy (this.gameObject);
	}		
}