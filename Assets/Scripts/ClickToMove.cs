using UnityEngine;
using System.Collections;
 
public class ClickToMove : MonoBehaviour {
	// transformer
	public Transform myTransform;
	//destination Point
	public Vector3 destinationPosition;
	//distance between myTransform and destinationPosition
	public float destinationDistance;
	
	
 	// move speed
	public float moveSpeed;						
 
 
 
	void Start () {
		// setting myTransform to this GameObject.transform
		myTransform = transform;	
		// prevents myTransform reset
		destinationPosition = myTransform.position;			
	}
 
	void Update () {
		if (Input.GetKeyDown (KeyCode.Alpha1)) {	//load levels 
			Application.LoadLevel("NPCBot");
		} else if (Input.GetKeyDown (KeyCode.Alpha2)) {
			Application.LoadLevel("ClickToMove");
		} else if (Input.GetKeyDown (KeyCode.Alpha3)) {
			Application.LoadLevel("Platformer");
		}
	
 
		// keep track of the distance between this gameObject and destinationPosition
		destinationDistance = Vector3.Distance(destinationPosition, myTransform.position);
 
		// To prevent shakin behavior when near destination
		if(destinationDistance < 5f){		
			moveSpeed = 0;
			
			// To Reset Speed to default
		}
		else if(destinationDistance > 5f){			
			moveSpeed = 3;
		}
 
 
		// Moves the Player if the Left Mouse Button was clicked
		if (Input.GetMouseButtonDown(0) && GUIUtility.hotControl ==0) {
 
			Plane playerPlane = new Plane(Vector3.up, myTransform.position);
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			float finaldistance = 0.0f;
 
			if (playerPlane.Raycast(ray, out finaldistance)) {
				Vector3 targetPoint = ray.GetPoint(finaldistance);
				destinationPosition = ray.GetPoint(finaldistance);
				Quaternion targetRotation = Quaternion.LookRotation(targetPoint - transform.position);
				myTransform.rotation = targetRotation;
			}
		}

 
		// stop moving when it gets there
		if(destinationDistance > .5f){
			myTransform.position = Vector3.MoveTowards(myTransform.position, destinationPosition, moveSpeed * Time.deltaTime);
		}
	}
}