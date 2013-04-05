using UnityEngine;
using System.Collections;

public class Sphere : MonoBehaviour
{
    private float forceToApply = 150f;

    private bool isKeyPressed = false;

    private void Update()
    {
        // Move the sphere
        float amountToMove = Input.GetAxisRaw("Horizontal") * forceToApply * Time.deltaTime;        
        rigidbody.AddForce(Vector3.right * amountToMove);


        if (Input.GetKey("left") || Input.GetKey("right"))
        {
            isKeyPressed = true;
        }
        else
        {
            isKeyPressed = false;
        }

        // Constraint the rotation
        rigidbody.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;
    }

    void OnCollisionEnter(Collision collisionInfo)
    {
		audio.Play();
        /*
        ContactPoint c = collisionInfo.contacts[0];
        Debug.Log("c.normal: " + c.normal.normalized);
        if (c.normal.normalized == Vector3.up)
        {
            Debug.Log("YKARI");
            rigidbody.velocity = c.normal.normalized * 8.0f;
        }
        else if (c.normal.normalized == Vector3.left)
        {
            Debug.Log("Left");
            rigidbody.velocity = c.normal.normalized * 1.75f;
        }
        else if (c.normal.normalized == Vector3.right)
        {
            Debug.Log("right");
            rigidbody.velocity = c.normal.normalized * 1.75f;
        }*/
        // Find the normal of collided surface
        Vector3 collisionNormal = collisionInfo.contacts[0].normal;
        //Debug.LogError("Cross:" + Vector3.Cross(collisionNormal, Vector3.up));
        //Debug.Log("collisionNormal: " + collisionNormal);
        // Make bounce
        /*if (Vector3.Cross(collisionNormal, Vector3.up) == Vector3.zero)
        {
            rigidbody.velocity = collisionNormal * 8.0f;
        }*/
        /*
        if (collisionNormal.normalized == Vector3.up)
        {
            rigidbody.velocity = collisionNormal * 8.0f;
        }*/


        ContactPoint c = collisionInfo.contacts[0];

        if (isKeyPressed)
        {
            float amountToJump = 8f;
            rigidbody.AddForce(Vector3.Reflect(Vector3.down, collisionInfo.contacts[0].normal) * amountToJump,
                               ForceMode.Impulse);
        }
        else
        {
            if (c.normal.normalized == Vector3.left)
            {
                Debug.Log("Left");
                rigidbody.velocity = c.normal.normalized*1.75f;
            }
            else if (c.normal.normalized == Vector3.right)
            {
                Debug.Log("right");
                rigidbody.velocity = c.normal.normalized*1.75f;
            }
            else
            {
                rigidbody.velocity = collisionNormal*8.0f;
            }
    }

    }
}


