using UnityEngine;
using System.Collections;

public class Mill : MonoBehaviour {

	// Use this for initialization
    public float angle = -0.3f;
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(0f, angle, 0f);
	}
	
	void OnCollisionEnter(Collision collisionInfo) 
	{
		Debug.Log("CARPTI!!!");
	}
}
