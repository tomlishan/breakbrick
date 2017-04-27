using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour {
    // ballActive: weather is on the board
    public float vertSpeed;
    public float maxHorizontalSpeed;
    private Rigidbody2D theRB;
    public bool ballActive;
    public Transform startPoint;
    private GameManager GM;
    private PaddleController paddle;
    void Start () {
        theRB = GetComponent<Rigidbody2D>();
        theRB.velocity = new Vector2(vertSpeed, vertSpeed);
        GM = FindObjectOfType<GameManager>();
        paddle = FindObjectOfType<PaddleController>();
    }
	
	void Update () {
        if (theRB.velocity.x >maxHorizontalSpeed)
        {
            theRB.velocity = new Vector2(maxHorizontalSpeed, theRB.velocity.y);
        }else if (theRB.velocity.x < -maxHorizontalSpeed)
        {
            theRB.velocity = new Vector2(-maxHorizontalSpeed, theRB.velocity.y);
        }
        if (!ballActive)
        {
            theRB.velocity = Vector2.zero;
            transform.position = startPoint.position;
        }

	}
    private void OnCollisionExit2D(Collision2D other)
    {
        if(other.gameObject.tag == "brick")
        {
            other.gameObject.GetComponent<BrickController>().DestroyBrick();
        }
        else if (other.gameObject.tag == "short brick")
        {
            other.gameObject.GetComponent<BrickController>().DestroyBrick();
            paddle.paddleshort();
        }
        else if (other.gameObject.tag == "long brick")
        {
            other.gameObject.GetComponent<BrickController>().DestroyBrick();
            paddle.paddlelong();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Respawn")
        {
            ballActive = false;
            GM.RespawnBall();
        }
    }

    public void ActivateBall()
    {
        ballActive = true;
        theRB.velocity = new Vector2(Random.Range(-vertSpeed,vertSpeed), vertSpeed);
    }
}
