
using UnityEngine;
using System.Collections;

public class MovingBlock2 : MonoBehaviour
{

    private bool isGoingDown = true;
    private float speed = 4f;


    void Update()
    {
        if (isGoingDown)
        {
            transform.Translate(Vector3.down * Time.deltaTime * speed);
            if (transform.position.y <= -1.5f)
            {
                isGoingDown = false;
            }
        }
        else
        {
            transform.Translate(Vector3.up * Time.deltaTime * speed);
            if (transform.position.y >= 2.5f)
            {
                isGoingDown = transform;
            }
        }
    }

    void OnCollisionEnter(Collision collisionInfo)
    {
        Debug.Log("CARPTI!!!");
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Application.LoadLevel(Application.loadedLevel);
        }
    }

}
