using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class randomColour : MonoBehaviour {

	// Use this for initialization
	void Start () {


		Color newCol = Random.ColorHSV (0, 1f, 0.8f, 1f, 0.7f, 0.7f);

		GetComponent<Renderer> ().material.color = newCol;


	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
