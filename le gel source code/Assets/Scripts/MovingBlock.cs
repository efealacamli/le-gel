
using UnityEngine;
using System.Collections;

public class MovingBlock : MonoBehaviour
{

    private bool isGoingDown = true;
    private float speed = 4f;


    void Update()
    {
        if (isGoingDown)
        {
            transform.Translate(Vector3.down * Time.deltaTime * speed);
            if (transform.position.y <= 0.3f)
            {
                isGoingDown = false;
            }
        }
        else
        {
            transform.Translate(Vector3.up * Time.deltaTime * speed);
            if (transform.position.y >= 6.5f)
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
