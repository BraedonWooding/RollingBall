using UnityEngine;
using System.Collections;
//Lowest (-15 pts)
public class Grey : Pickup
{
	public override void ApplyEffects (Player playerClass)
	{
		playerClass.amountOfPickupsPickedUp += 2;
		playerClass.score -= 15;
		Destroy (this.gameObject);
	}
}