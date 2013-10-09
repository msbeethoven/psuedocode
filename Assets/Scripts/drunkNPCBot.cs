using UnityEngine;
using System.Collections;

public class drunkNPCBot : MonoBehaviour {
	
	//Vector3 fwd = Vector3.forward;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Alpha1)) {			//load levels
			Application.LoadLevel("NPCBot");
		} else if (Input.GetKeyDown (KeyCode.Alpha2)) {
			Application.LoadLevel("ClickToMove");
		} else if (Input.GetKeyDown (KeyCode.Alpha3)) {
			Application.LoadLevel("Platformer");
		}
		
	}
	
	void FixedUpdate() { 
		//if (Physics. Raycast( transform.position, transform.forward, 5f) ) {
			//int randomNumber = Random.Range (0, 10);
			//if (randomNumber < 5) {
			// 	transform.Rotate (0f, -90f, 0f);
			//}
			// else {
				// transform. Rotate (0f, 0f, 90f); 
		//}
		
	//}
//}
		Ray ray = new Ray (transform.position, Vector3.forward); // what Ray ray is doing is using Unity's Ray but making it your own ray, but using their built in structure
		RaycastHit hit = new RaycastHit();
		
		rigidbody.AddRelativeForce(transform.forward * 10); 
		if (Physics.Raycast(ray, out hit, 10f)){// if the ray is cast, and it registers a hit, at a distance of at most at most 10 m) //transform.rotate (fill out the variables)
				int x = Random.Range (0, 10); 
				if (x < 5) { //random = 0 > f > 10//if (random <5 )
					transform.Rotate (new Vector3 (0, 90, 0));
				}else{
					transform.Rotate( new Vector3 (0, -90, 0));
				}
		}
		
	}
	
}
	
