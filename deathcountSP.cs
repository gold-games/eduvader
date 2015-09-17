using UnityEngine;
using System.Collections;

public class deathcountSP : MonoBehaviour {
	public GameObject player1;
	float deathtimeout = 0;


	int deathCounter;
	void Start(){

		}
	void FixedUpdate(){
		deathtimeout -= Time.deltaTime;

		Health eh = (Health)player1.GetComponent("Health");

//		Debug.Log (eh.currentHealth);
		if(eh.currentHealth <= 0 && deathtimeout <= 0){
			deathCounter++;
			Debug.Log("deaths:" + deathCounter);
			deathtimeout = 8.0f;
		}
	}
	
	void OnGUI(){
		//Draws out a box on position x and y, with a specified width and height and width.
		GUI.Label(new Rect(5, 40, 120, 20),"Deaths:" + deathCounter);
	}
}
