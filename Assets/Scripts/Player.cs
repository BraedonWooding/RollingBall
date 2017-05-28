using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using UnityEngine.UI;

public class Player : MonoBehaviour
{

	Rigidbody rb;

	public bool inAir;
	public bool invincible; //Talk about this
	bool finished;

	public Dictionary<string, float> stats = new Dictionary<string, float> ();
	public float score;
	public int amountOfPickupsPickedUp;
	float time = .5f;

	public Text scoreTxt;
	public GameObject tutorialPanel;
	public Text tutorialText;
	public Jumps jumpScript;

	void Start ()
	{
		rb = this.GetComponent<Rigidbody> ();
		stats.Add ("speed", 10);
		stats.Add ("hitPoints", 3);
		stats.Add ("damage", 0);
		stats.Add ("jumpHeight", 40);
		stats.Add ("numberOfJumps", 1);
		stats.Add ("jumpsCurrentlyJumped", 0);
	}

	void Update ()
	{
		if (!finished) {
			score -= Time.deltaTime;
		}
		scoreTxt.text = "Score: " + score;

		if (invincible) {
			time -= Time.deltaTime;
			if (time <= 0) {
				invincible = false;
			}
		}

		if (stats ["hitPoints"] <= 0) {
			//Dead
			Application.LoadLevel (Application.loadedLevel);
		}
	}
	
	void FixedUpdate ()
	{
		float x = Input.GetAxis ("Horizontal");
		float z = Input.GetAxis ("Vertical");
		float y = 0;
		if (Input.GetKeyDown (KeyCode.Space) && !inAir) {
			if (stats ["numberOfJumps"] != stats ["jumpsCurrentlyJumped"]) {
				y = stats ["jumpHeight"];
				stats ["jumpsCurrentlyJumped"] ++;
				jumpScript.Jumped ();
			} else {
				inAir = true;
			}
		}

		Vector3 movement = new Vector3 (x, y, z);
		rb.AddForce (movement * stats ["speed"]);
	}

	void OnTriggerEnter (Collider col)
	{

		if (col.gameObject.tag == "Respawn") {
			Application.LoadLevel (Application.loadedLevel);
		}

		if (col.gameObject.tag == "EndArea") {
			//Completed
			finished = true;
			col.gameObject.GetComponent<Animator> ().SetTrigger ("NextLevel");
			StartCoroutine (NextLevel (col.name));
		}

		if (col.gameObject.tag == "Pickup") {
			col.gameObject.GetComponent<Pickup> ().ApplyEffects (this);
		}

		if (col.gameObject.tag == "Tutorial") {
			tutorialPanel.SetActive (true);
			tutorialText.text = col.GetComponent<TutorialPopup> ().PopupText;
			Time.timeScale = 0;
		}
	}

	void OnCollisionEnter (Collision col)
	{
		if (col.gameObject.tag == "Area") {
			inAir = false;
			stats ["jumpsCurrentlyJumped"] = 0;
			jumpScript.Reset ();
		}
		if (col.gameObject.tag == "Enemy") {
			Enemy enemy = col.gameObject.GetComponent<Enemy> ();
			enemy.ApplyDamage (stats ["damage"]);
			if (!invincible && col.gameObject != null) {
				Debug.Log ("hit" + col.gameObject.name);
				col.gameObject.GetComponent<Enemy> ().ApplyEffects (this);
			}
		}
	}

	public void ResetTime ()
	{
		Time.timeScale = 1; 
	}

	void OnCollisionExit (Collision col)
	{
		if (col.gameObject.tag == "Area" && stats ["numberOfJumps"] == stats ["jumpsCurrentlyJumped"]) {
			inAir = true;
		}
	}

	IEnumerator NextLevel (string levelName)
	{
		yield return new WaitForSeconds (1.5f);
		Application.LoadLevel (levelName);
	}
}