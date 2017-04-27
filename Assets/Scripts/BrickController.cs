using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickController : MonoBehaviour {
    public int brickValue;
    private GameManager GM;
    public GameObject scoreEffect;
	void Start () {
        GM = FindObjectOfType<GameManager>();
	}
	
	void Update () {
		
	}
    public void DestroyBrick()
    {
        GM.Addscore(brickValue);
        GameObject scoreObject = (GameObject)Instantiate(scoreEffect,transform.position,transform.rotation);
        scoreObject.GetComponent<ScoreEffect>().scoreText.text = "" + brickValue;
        Destroy(gameObject);
    }
}
