using UnityEngine;
using System.Collections;

public class HUD : MonoBehaviour {
	Health myHealth;
	
	void Awake()
	{
		myHealth = GetComponent<Health>();
	}

	void OnGUI()
	{
		if (myHealth.currentHealth <= 0) {
						GUI.Label (new Rect ((Screen.width/2)-60, (Screen.height/4)-10, 120, 20), "You died");
				}  
						GUI.Label (new Rect (5, 25, 120, 20), "Health: " + myHealth.currentHealth + "/" + myHealth.maxHealth);
				
	}
}
