using UnityEngine;
using System.Collections;

public class movieplay : MonoBehaviour {
    public bool isPlaying;
    public MovieTexture movTexture;
    void Start()
    {
      
        GetComponent<Renderer>().material.mainTexture = movTexture;
        movTexture.Play();
    }
    void Update()
    {
        if(movTexture.isPlaying == false) {
            Application.LoadLevel("menuscreen");
        }
    }
}
