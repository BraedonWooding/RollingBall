using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class StatDisplayer : MonoBehaviour
{
	Player playerToAccess;
	public string StatToAccess;
	public Text txtToDisplay;

	void Start ()
	{
		playerToAccess = GameObject.Find ("Player").GetComponent<Player> ();
	}

	void Update ()
	{
		txtToDisplay.text = playerToAccess.stats [StatToAccess] + "x";
	}
}