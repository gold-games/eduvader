using UnityEngine;
using System.Collections;

public class menuscreen : MonoBehaviour {

	public Camera[] cameras;
	public Texture myGUITexture;
	public Texture alphasign;
	public GUISkin skin;
	
	private float gldepth = -0.5f;
	private float startTime = 0.1f;
	
	public Material mat;
	
	

	
	
	

	
	public GameObject start;
	
	public string url = "unity.html";
	
	public Color statColor = Color.white;
	
	public string[] credits= {""
	} ;
	public Texture[] crediticons;
	
	public enum Page {
		None,Main,Options,Credits
	}
	
	private Page currentPage;
	

	
	private int toolbarInt = 0;
	private string[]  toolbarstrings =  {"Audio"};
	
	
	void Start() {
		
		Time.timeScale = 1;

		//pauseFilter = Camera.main.GetComponent<SepiaToneEffect>();
		PauseGame();
		GetComponent<AudioSource>().Play ();
	}
	
	
	
	
	
	static bool IsDashboard() {
		return Application.platform == RuntimePlatform.OSXDashboardPlayer;
	}
	
	static bool IsBrowser() {
		return (Application.platform == RuntimePlatform.WindowsWebPlayer ||
		        Application.platform == RuntimePlatform.OSXWebPlayer);
	}
	
	void LateUpdate () {
		
		
		/*if (Input.GetKeyDown("escape")) 
		{
			switch (currentPage) 
			{
				
			case Page.None: 
				PauseGame(); 
				break;
				
			case Page.Main: 
				if (!IsBeginning()) 
					UnPauseGame(); 
				break;
				
			default: 
				currentPage = Page.Main;
				break;
			}
		}*/
	}
	
	void OnGUI () {
		if (skin != null) {
			GUI.skin = skin;
		}
		
		
		if (IsGamePaused()) {
			GUI.Box(new Rect( (Screen.width / 2) - 256, (Screen.height / 2) - 262, 512, 512), myGUITexture);
			GUI.Box(new Rect( (Screen.width / 2) - 100, (Screen.height / 2) - 150, 200, 75), alphasign);
			GUI.color = statColor;
			switch (currentPage) {
			case Page.Main: MainPauseMenu(); break;
			case Page.Options: ShowToolbar(); break;
			case Page.Credits: ShowCredits(); break;
			}
		}   
	}
	

	
	void ShowToolbar() {
		BeginPage(300,300);
		toolbarInt = GUILayout.Toolbar (toolbarInt, toolbarstrings);
		switch (toolbarInt) {
		case 0: VolumeControl(); break;
		
		}
		EndPage();
	}
	
	void ShowCredits() {
		BeginPage(300,300);
		foreach(string credit in credits) {
			GUILayout.Label(credit);
		}
		foreach( Texture credit in crediticons) {
			GUILayout.Label(credit);
		}
		EndPage();
	}
	
	void ShowBackButton() {
		if (GUI.Button(new Rect(20, Screen.height - 50, 50, 20),"Back")) {
			currentPage = Page.Main;
		}
	}
	

	
	
	
	
	
	void VolumeControl() {
		GUILayout.Label("Volume");
		AudioListener.volume = GUILayout.HorizontalSlider(AudioListener.volume, 0, 1);
	}
	
	
	
	
	
	
	
	void BeginPage(int width, int height) {
		GUILayout.BeginArea( new Rect((Screen.width - width) / 2, (Screen.height - height) / 2, width, height));
	}
	
	void EndPage() {
		GUILayout.EndArea();
		if (currentPage != Page.Main) {
			ShowBackButton();
		}
	}
	
	bool IsBeginning() {
		return (Time.time < startTime);
	}
	
	
	void MainPauseMenu() {
		BeginPage(200,200);

		if (GUILayout.Button ("Play")) {
			Application.LoadLevel("level1");
			
		}
	
		if (GUILayout.Button ("Options")) {
			currentPage = Page.Options;
		}
		
		
		if (GUILayout.Button ("Exit")) {
			Application.Quit ();
		}
		EndPage();
	}
	
	
	

	
	void PauseGame() {
		//savedTimeScale = Time.timeScale;
		Time.timeScale = 0;
		AudioListener.pause = false;
		//if (pauseFilter) 
		//	pauseFilter.enabled = true;
		currentPage = Page.Main;
	}
	
	void UnPauseGame() {
		//Time.timeScale = savedTimeScale;
		AudioListener.pause = false;
		//if (pauseFilter) 
		//	pauseFilter.enabled = false;
		
		currentPage = Page.None;
		
		if (IsBeginning() && start != null) {
			start.active = true;
		}
	}
	
	bool IsGamePaused() {
		return (Time.timeScale == 0);
	}
	
	void OnApplicationPause(bool pause) {
		if (IsGamePaused()) {
			AudioListener.pause = true;
		}
	}
}