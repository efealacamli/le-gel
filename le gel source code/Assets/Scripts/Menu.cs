using UnityEngine;
using System.Collections;

public class Menu : MonoBehaviour {

	// Use this for initialization
	
	public GUISkin customSkin1;
	public GUISkin customSkin2;
	public Texture2D headerTexture;
	
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnGUI() {
		
		GUI.skin = customSkin1;
		
		GUI.Box(new Rect(60, 10, 420, 210), headerTexture);
		
		GUI.skin = customSkin2;
 		if (GUI.Button(new Rect(230, 240, 150, 55), "New Game"))
		{
            Application.LoadLevel(1);
		}
		if (GUI.Button(new Rect(230, 300, 150, 55), "How to play"))
		{
            Application.LoadLevel(4);
		}
		if (GUI.Button(new Rect(230, 360, 150, 55), "Credits"))
		{
            Application.LoadLevel(5);
		}
	}
}
