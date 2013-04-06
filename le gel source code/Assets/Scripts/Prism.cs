using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Prism : MonoBehaviour
{

    public float t = 6f;

    float moveSpeed = 5;
    float minVelocity = 2f;
    float maxVelocity = 1f;
    float currentVelocity;

    public HingeJoint hj;


    public void resetPrism()
    {
        Destroy(hj);
        rigidbody.AddTorque(new Vector3(0,0,0));
    }

    // Use this for initialization
    private void Start()
    {

    }

    private Vector3 rotatingAround = Vector3.up;

    private void FixedUpdate()
    {
        if (Input.GetKey("left"))
        {
            if (currentVelocity < maxVelocity)
            {
                rotatingAround = Vector3.down;
                //rigidbody.AddForce(Vector3.left * 20);
                rigidbody.AddTorque(Vector3.forward * 20);
            }
        }
        if (Input.GetKey("right"))
        {
            if (currentVelocity < maxVelocity)
            {
                rotatingAround = Vector3.up;
                rigidbody.AddTorque(Vector3.back * 20);
            }

        }
    }

    List<ContactPoint> contactCandidates = new List<ContactPoint>(); 
	
	void OnCollisionEnter(Collision collisionInfo)
	{
		audio.Play();
	}
	
    private void OnCollisionStay(Collision collision)
    {
        foreach (ContactPoint cp in collision.contacts)
        {
            Vector3 position = cp.point;
            Vector3 localPosition = transform.InverseTransformPoint(position);
            if (GetComponent<HingeJoint>() == null)
            {
                HingeJoint h = gameObject.AddComponent<HingeJoint>();
                h.axis = Vector3.up;
                localPosition.y = 0;
                h.anchor = localPosition;
                hj = h;
            } else {
				

                HingeJoint h = hj;
                Vector3 oldHingePosition = h.anchor;
                Vector3 r = Vector3.Cross(localPosition, oldHingePosition);

                if (Vector3.Dot(r, rotatingAround) > 0)
                {
					
					//audio.Play();

                    localPosition.y = 0;

                    if ((h.anchor - localPosition).sqrMagnitude > .25)
                    {
                        if(localPosition.x > 0)
                        {
                            localPosition.x = .3f;
                            if (localPosition.z > 0)
                            {
                                localPosition.z = .5f;
                            } else
                            {
                                localPosition.z = -.5f;
                            }
                        } else
                        {
                            localPosition.x = -.6f;
                            localPosition.z = 0f;
                        }
                        h.anchor = localPosition;
                    } 
                    
                }
            }
        }
    }


}

