using UnityEngine;
using System.Collections;

public class Credit : MonoBehaviour {
	public Texture2D howToPlayTexture;
	public GUISkin customSkin;
	
	void OnGUI() 
	{
		GUI.skin = customSkin;
		GUI.Box(new Rect(0, 0, 600, 450), howToPlayTexture);
		if (GUI.Button(new Rect(230, 360, 150, 55), "Back"))
		{
            Application.LoadLevel(0);
		}
	}
}
