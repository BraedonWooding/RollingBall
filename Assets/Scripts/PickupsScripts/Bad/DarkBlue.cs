using UnityEngine;
using System.Collections;
//Second Lowest (-25 pts + Jump Height --)
public class DarkBlue : Pickup
{
	public override void ApplyEffects (Player playerClass)
	{
		playerClass.amountOfPickupsPickedUp += 2;
		playerClass.score += 25;
		playerClass.stats ["jumpHeight"] -= 10;
		Destroy (this.gameObject);
	}		
}