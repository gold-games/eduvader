using UnityEngine;
using System.Collections;

public class countdowntimer : MonoBehaviour {
	int minutes;
	int seconds;
	string niceTime;
	public static bool timeStarted = true;
	 public float timeLeft = 600.0f;
	
	void Update()
	{
		if (timeStarted == true) {
			timeLeft -= Time.deltaTime;
			}
		if(timeLeft < 0)
		{
			Application.LoadLevel("MPvictory");
		}
	}
	void OnGUI() {
		minutes = Mathf.FloorToInt(timeLeft / 60F);
		seconds = Mathf.FloorToInt(timeLeft - minutes * 60);
		
		niceTime = string.Format("{00:00}:{01:00}", minutes, seconds);
		
		GUI.Label(new Rect(10,10,250,100), niceTime);
	}
}