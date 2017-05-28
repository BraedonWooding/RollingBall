using UnityEngine;
using System.Collections;
//Middle (-50 pts + HP --)
public class DarkGreen : Pickup
{
	public override void ApplyEffects (Player playerClass)
	{
		playerClass.amountOfPickupsPickedUp += 2;
		playerClass.score += 50;
		playerClass.stats ["hitPoints"] -= 1;
		Destroy (this.gameObject);
	}	
}