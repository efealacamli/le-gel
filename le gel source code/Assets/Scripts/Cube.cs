using UnityEngine;
using System.Collections;

public class Cube : MonoBehaviour {
	
	// Update is called once per frame
	void Update ()
	{
		
        if (Input.GetKey("left"))
        {
            rigidbody.position += Vector3.left * Time.deltaTime * 6;
			audio.Play();
        }
        if (Input.GetKey("right"))
        {
            rigidbody.position += Vector3.right * Time.deltaTime * 6;
			audio.Play();
        }
		
		
		
	}
}
