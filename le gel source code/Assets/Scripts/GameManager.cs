using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{

    public Texture2D sphereTexture;
    public Texture2D triangleTexture;
    public Texture2D cubeTexture;

    public GUISkin customSkin;

    private string[] messages = {"Use arrow keys to move!", "This is a cube!\nIt's abiliy is being fast!", "Use that ability to pass\n the moving blocks!", "Cube cannot jump!\n Press 2 and be sphere!", "That platform is too high\nfor a sphere.\nPress 3 and be prism."};
    public int stringIndex = 0;

	    
	private static GameManager instance;
	
	GameManager()
    {
        instance = this;
    }

    public static GameManager getInstance()
    {
        return instance;
    }
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame


	void Update () {
	    if (Input.GetKeyDown("space"))
	    {
	        stringIndex++;
	        stringIndex = stringIndex%4;
            Debug.LogError("space is pressed");
	    }
	}

    void OnGUI()
    {
        GUI.skin = customSkin;

        GUI.Box(new Rect(5, 5, 142, 52), "");
        GUI.Box(new Rect(10, 10, 42, 42), sphereTexture);
        GUI.Box(new Rect(55, 10, 42, 42), triangleTexture);
        GUI.Box(new Rect(100, 10, 42, 42), cubeTexture);

        GUI.Label(new Rect(100, 100, 250, 150), messages[stringIndex]);
    }
}
