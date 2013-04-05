using UnityEngine;
using System.Collections;

public class Magnetism : MonoBehaviour {

    float moveSpeed = 5;
    float minVelocity = 2f;
    float maxVelocity = 1f;
    float currentVelocity;
    private GameObject magneticRedObject;
    private GameObject magneticBlackObject;

	// Use this for initialization
	void Start () {
	
	}


    void Awake()
    {
        magneticRedObject = GameObject.FindGameObjectWithTag("MagneticRed");
        magneticBlackObject = GameObject.FindGameObjectWithTag("MagneticBlack");
    }
	
	// Update is called once per frame
	void Update () {

        //transform.rigidbody.constraints = RigidbodyConstraints.FreezePositionZ;

        if (Input.GetKey("left"))
        {
            if (currentVelocity < maxVelocity)
            {
                //rotatingAround = Vector3.left;
                //rigidbody.AddForce(Vector3.left * 20);
                rigidbody.AddTorque(Vector3.left * 10);
            }
        }
        if (Input.GetKey("right"))
        {
            if (currentVelocity < maxVelocity)
            {
                //rotatingAround = Vector3.right;
                //rigidbody.AddForce(Vector3.right * 20);
                rigidbody.AddTorque(Vector3.right * 10);
            }

        }

        if (Input.GetKey(KeyCode.Q))
        {
            Debug.Log("q is pressed");
        
        }

	}

    void OnTriggerStay(Collider other)
    {
        if(gameObject.tag.Equals("MagnetismCollider"))
        {
            if (other.CompareTag("MagneticRed"))
            {
                //Debug.Log("magnetic red");
                Vector3 difference = gameObject.transform.position - other.transform.position;
                other.rigidbody.AddForce(-difference * 2f);
            }

            else if(other.CompareTag("MagneticBlack"))
            {
                //Debug.Log("magnetic black");
                Vector3 difference = gameObject.transform.position - other.transform.position;
                other.rigidbody.AddForce(difference * 2f);
            }
        }
    }

}
