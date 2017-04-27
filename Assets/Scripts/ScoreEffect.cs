using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreEffect : MonoBehaviour {
    public float lifetime;
    public Text scoreText;
	void Start () {
		
	}

    //lifetime = lifetime - Time.deltaTime Countdown second
	void Update () {
        lifetime = lifetime - Time.deltaTime;
        if(lifetime < 0)
        {
            Destroy(gameObject);
        }
	}
}
