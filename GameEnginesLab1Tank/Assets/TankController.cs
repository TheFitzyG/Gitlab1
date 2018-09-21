using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankController : MonoBehaviour {

	Rigidbody rb;

	public float speed;

	public Transform SpawnPoint;
	public GameObject Projectile;

	public float shotSpeed = 100f;

	// Use this for initialization
	void Start () {

		rb = GetComponent<Rigidbody> ();

	}
	
	// Update is called once per frame
	void FixedUpdate () {


		Vector2 MovementVec = new Vector2 (Input.GetAxis ("Horizontal"), Input.GetAxis ("Vertical"));

		MovementVec.Normalize ();
		MovementVec *= speed;

		rb.AddRelativeForce (0, 0, MovementVec.y);
	//rb.AddRelativeTorque(0, MovementVec.x, 0);
		//rb.MoveRotation(transform.rotation 

		//rb.add

		transform.Rotate (0, MovementVec.x  * Time.fixedDeltaTime, 0);


		if (Input.GetKeyDown (KeyCode.Space)) {


			GameObject temp = Instantiate (Projectile);

			temp.transform.position = SpawnPoint.position;
			temp.transform.rotation = SpawnPoint.rotation;

			temp.GetComponent<Rigidbody> ().AddForce (SpawnPoint.forward * shotSpeed, ForceMode.Impulse);

			Destroy (temp, 5f);

		}

	}
}
