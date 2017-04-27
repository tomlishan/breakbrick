using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleController : MonoBehaviour {
    public float speed;
    public float direction;
    

    public Transform rightLimit;
    public Transform leftLimit;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.D))
        {
            transform.position = new Vector3(transform.position.x + (speed*Time.deltaTime), transform.position.y, transform.position.z);
            direction = 1;
        }

        else if (Input.GetKey(KeyCode.A))
        {
            transform.position = new Vector3(transform.position.x - (speed * Time.deltaTime), transform.position.y, transform.position.z);
            direction = -1;
        }
        else
        {
            direction = 0;
        }
        if (transform.position.x > rightLimit.position.x)
        {
            transform.position = new Vector3(rightLimit.position.x, transform.position.y, transform.position.z);
        } else if (transform.position.x <leftLimit.position.x)
        {
            transform.position = new Vector3(leftLimit.position.x, transform.position.y, transform.position.z);
        }
	}
    private void OnCollisionEnter2D(Collision2D other)
    {
        other.rigidbody.velocity = new Vector2(other.rigidbody.velocity.x,other.rigidbody.velocity.y);
    }
    public void paddleshort()
    {
        transform.localScale -= new Vector3(0.2F, 0, 0);
    }
    public void paddlelong()
    {
        transform.localScale += new Vector3(0.2F, 0, 0);
    }
}
