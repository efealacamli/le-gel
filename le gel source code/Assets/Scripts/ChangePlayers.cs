using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ChangePlayers: MonoBehaviour
{
    private static ChangePlayers instance;
    public int passingPointIndex;

    public GameObject ucgen;
    private Prism prismScript;

    ChangePlayers()
    {
        instance = this;
    }

    public static ChangePlayers getInstance()
    {
        return instance;
    }
	
    public GameObject player1Prefab;
    public GameObject player2Prefab;
    public GameObject player3Prefab;
    public GameObject activePlayer;

    public int selectedCharacter = 1;
    public string characterName;
    private Vector3 lastPosition = new Vector3(-3.52f, -1.76f, 8.82f);

    public Dictionary<string, GameObject> playerList = new Dictionary<string, GameObject>();

    // Use this for initialization
    private void Awake()
    {
        playerList.Add("Player1", player1Prefab);
        playerList.Add("Player2", player2Prefab);
        playerList.Add("Player3", player3Prefab);
    }
	
    private void Start()
    {
        changeCharacter(selectedCharacter);
        prismScript = ucgen.GetComponent<Prism>();
    }

    void changeCharacter(int characterIndex)
    {
        for (int i = 1; i < 4; i++)
        {
            if (i != selectedCharacter)
            {
                characterName = "Player" + i;
                Debug.Log("Passive: " + characterName);
                playerList[characterName].SetActiveRecursively(false);
            }
            else
            {
                characterName = "Player" + selectedCharacter;
                Debug.Log("Active: " + characterName);
                playerList[characterName].transform.position = lastPosition; //+ new Vector3(0.0f, 1.5f, 0.0f);
                playerList[characterName].SetActiveRecursively(true);
                activePlayer = playerList[characterName];
            }
        }
    }

    // Update is called once per frame
    private void Update()
    {
		characterName = "Player" + selectedCharacter;
        lastPosition = playerList[characterName].transform.position;
		
        //Debug.Log("pos y: " + activePlayer.transform.position.y);

        if (activePlayer.transform.position.y <= -20f)
        {
            Application.LoadLevel(Application.loadedLevel);
        }

		if (Input.GetKeyDown("1")) // top
		{
		    selectedCharacter = 1;
		    changeCharacter(selectedCharacter);
		}

        if (Input.GetKeyDown("2")) // ucgen
        {
            selectedCharacter = 2;
            prismScript.resetPrism(); 
            changeCharacter(selectedCharacter);
        }

        if (Input.GetKeyDown("3")) // kare
        {
            selectedCharacter = 3;
            changeCharacter(selectedCharacter);
        }

        if (Input.GetKeyDown("4")) // jel
        {
            selectedCharacter = 4;
            changeCharacter(selectedCharacter);
        }
    }
	
}
