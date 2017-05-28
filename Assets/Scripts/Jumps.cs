using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public class Jumps : MonoBehaviour
{
	public GameObject prefab;
	public Transform holder;
	public Player playerScript;
	List<Image> jumpCounter = new List<Image> ();
	int currentJump;

	public void Jumped ()
	{
		jumpCounter [currentJump].color = Color.green;
		currentJump++;
	}

	public void Reset ()
	{
		currentJump = 0;
		for (int i = 0; i < jumpCounter.Count; i++) {
			jumpCounter [i].color = Color.white;
		}
	}

	void Update ()
	{
		if (holder.childCount != playerScript.stats ["numberOfJumps"]) {
			foreach (Transform child in holder) {
				Destroy (child.gameObject);
			}
			jumpCounter = new List<Image> ();

			for (int i = 0; i < playerScript.stats ["numberOfJumps"]; i++) {
				GameObject go = (GameObject)Instantiate (prefab);
				go.transform.SetParent (holder);
				go.name = "" + i;
				jumpCounter.Add (go.GetComponent<Image> ());
			}
		}
	}
}