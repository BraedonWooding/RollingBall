using UnityEngine;
using System.Collections;
//Moar Jumps
public class White : Pickup
{
	public override void ApplyEffects (Player playerClass)
	{
		playerClass.amountOfPickupsPickedUp ++;
		playerClass.score += 200;
		playerClass.stats ["numberOfJumps"] += 1;
		Destroy (this.gameObject);
	}	
}
