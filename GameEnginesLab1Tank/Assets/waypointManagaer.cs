using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class waypointManagaer : MonoBehaviour {

	public int waypointCount;

	public float distance;

	public float minDistance; 

	int currentWaypoint;

	public float moveSpeed;
	public float rotationSpeed; 

	public List<GameObject> waypoints = new List<GameObject>();

	Rigidbody rb;

	// Use this for initialization
	void Start () {

		rb = GetComponent<Rigidbody> ();

		float roationAmount = (360f) / waypointCount;

	///	roationAmount = roationAmo //Math.Rad2Deg(roationAmount);

		for (int i = 0; i < waypointCount; i++) {

			//Instantiate(new GameObject);
			GameObject temp = Instantiate(new GameObject()); 
			temp.transform.position = transform.position + (transform.forward * distance);
			//Gizmos.DrawWireSphere (temp.transform.position, 0.5f);



			waypoints.Add (temp);


			transform.Rotate (0, roationAmount, 0);



		}






	}

	void OnDrawGizmos(){

		foreach (GameObject G in waypoints) {
			Gizmos.DrawWireSphere (G.transform.position, 0.5f);
		}

	}
	
	// Update is called once per frame
	void FixedUpdate () {


		float dist = Vector3.Distance (waypoints [currentWaypoint].transform.position, transform.position);
		if (dist < minDistance) {

			currentWaypoint++; 

			if (currentWaypoint > waypoints.Count - 1) {
				currentWaypoint = 0;

			}
		}


		transform.position = Vector3.MoveTowards (transform.position, waypoints [currentWaypoint].transform.position, moveSpeed * Time.deltaTime);
		 transform.LookAt (waypoints [currentWaypoint].transform.position);
		//transform.rotation = Quaternion.RotateTowards(transform.rotation, (waypoints[currentWaypoint].transform.localRotation), rotationSpeed *Time.deltaTime);


		/*
		Vector3 direction = waypoints [currentWaypoint].transform.position - transform.position; 

		direction.y = 0f; 


		direction.Normalize ();

		float rotateAmount = Vector3.Cross (direction, transform.forward).y;

		transform.Rotate (0, rotationSpeed * Time.deltaTime * rotateAmount, 0);

		rb.AddRelativeForce (0, 0, moveSpeed);
*/

	}
}
