using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using System.Collections;

public class PassingPoint : MonoBehaviour
{
    private GameObject mainCamera;
    private ChangePlayers changePlayers;
    private GameObject[] unsortedPassingPoints;
    private GameObject[] sortedPassingPoints;
    private GameObject firstPassingPoint;
    private GameObject fakeFirstPassingPoint;
    private GameObject lastPassingPoint;
    private int lengthSortedPassingPoints;
    private String[] allTags = {"PassingPoint", "FakeFirstPassingPoint"};
    private GameManager gameManager;
    
    void Awake()
    {
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
        changePlayers = ChangePlayers.getInstance();
		gameManager = GameManager.getInstance();
        unsortedPassingPoints = GameObject.FindGameObjectsWithTag("PassingPoint");
        firstPassingPoint = GameObject.FindGameObjectWithTag("FirstPassingPoint");
        lastPassingPoint = GameObject.FindGameObjectWithTag("LastPassingPoint");
        if (GameObject.FindGameObjectWithTag("FakeFirstPassingPoint"))
        {
            Debug.Log("FAKE");
            unsortedPassingPoints[unsortedPassingPoints.Length] = GameObject.FindGameObjectWithTag("FakeFirstPassingPoint");
        }

        //Debug.Log("Size: " + unsortedPassingPoints.Length);
    }
 
    List<GameObject> FindGameObjectsWithMTag (String[] tags) {
        var combinedList = new List<GameObject>();
        for (int i = 0; i < tags.Length; i++) {
            var taggedObjects = GameObject.FindGameObjectsWithTag(tags[i]);
            combinedList.AddRange(taggedObjects);
        }
        return combinedList;
    }

    void Start()
    {
        //sorting passing points
        sortedPassingPoints = unsortedPassingPoints.OrderBy(v => v.transform.position.x).ToArray<GameObject>();
        //initial stage and its position
        mainCamera.camera.orthographicSize = (sortedPassingPoints[0].transform.position.x - firstPassingPoint.transform.position.x) * 0.5f - 2f;
        mainCamera.transform.position = new Vector3(firstPassingPoint.transform.position.x + mainCamera.camera.orthographicSize + 2f, 0, 0);
        lengthSortedPassingPoints = sortedPassingPoints.Length;
        //gameManager = GetComponent<GameManager>();
        
    }

	// Use this for initialization

    void Update()
    {
    }

    void OnTriggerEnter(Collider other)
    {
		if (gameObject.tag == "LastPassingPoint") 
		{
			Application.LoadLevel(Application.loadedLevel + 1);
		}
		else
		{
	        if (other.gameObject.tag == "Player")
	        {
	            int search = gameObject.GetInstanceID();
	            int index =
	                sortedPassingPoints.Select((item, i) => new {Item = item.GetInstanceID(), Index = i}).First(
	                    x => x.Item == search).Index;
	            Debug.LogError("index: " + index);
	            //if player collide from left to the passing point
	            if (gameObject.transform.position.x > changePlayers.activePlayer.transform.position.x)
	            {
					if (Application.loadedLevel == 1) 
					{
						gameManager.stringIndex++;	
					}
	                if ((lengthSortedPassingPoints - 1) == index)
	                {
	                    //if it is the LastPassingPoint
	                    mainCamera.camera.orthographicSize = (lastPassingPoint.transform.position.x -
	                                                          sortedPassingPoints[index].transform.position.x)*0.5f - 2f;
	                    mainCamera.transform.position =
	                        new Vector3(
	                            sortedPassingPoints[index].transform.position.x + mainCamera.camera.orthographicSize + 2f, 0,
	                            0);
	
	                    if (gameObject.tag == "LastPassingPoint")
	                    {
	                        Application.LoadLevel(Application.loadedLevel);
	                        Debug.LogWarning("SONSONSON");
	                    }
	                }
	                else
	                {                
	                        mainCamera.camera.orthographicSize = (sortedPassingPoints[index + 1].transform.position.x -
	                                                              sortedPassingPoints[index].transform.position.x)*0.5f - 2f;
	                        mainCamera.transform.position =
	                            new Vector3(
	                                sortedPassingPoints[index].transform.position.x + mainCamera.camera.orthographicSize + 2f, 0,
	                                0);
	
	                }
	
	            }
	                //if player collide from right to the passing point
	            else if (gameObject.transform.position.x < changePlayers.activePlayer.transform.position.x)
	            {
					if (Application.loadedLevel == 1) 
					{
						gameManager.stringIndex--;	
					}
					
	                if (index == 0)
	                {
	                    //if it is the FirstPassingPoint
	                    mainCamera.camera.orthographicSize = (sortedPassingPoints[index].transform.position.x -
	                                                          firstPassingPoint.transform.position.x)*0.5f - 2f;
	                    mainCamera.transform.position =
	                        new Vector3(
	                            sortedPassingPoints[index].transform.position.x - mainCamera.camera.orthographicSize - 2f, 0,
	                            0);
	                }
	                else
	                {
	                    mainCamera.camera.orthographicSize = (sortedPassingPoints[index].transform.position.x -
	                                                          sortedPassingPoints[index - 1].transform.position.x)*0.5f - 2f;
	                    mainCamera.transform.position =
	                        new Vector3(
	                            sortedPassingPoints[index].transform.position.x - mainCamera.camera.orthographicSize - 2f, 0,
	                            0);
	                }
	
	            }
	
	
	        }
		}
    }
}
