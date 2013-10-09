using UnityEngine;
using System.Collections;


public class Platformer : MonoBehaviour {

	// move vectors 
	Vector3 leftmove = new Vector3(10f, 0f, 0f);
	Vector3 rightmove = new Vector3(-10f, 0f, 0f); 
	Vector3 downmove = new Vector3 (0f, 0f, 10f);
	Vector3 upmove = new Vector3 (0f, 0f, -10f);
	Vector3 jump = new Vector3(0f, 5f, 0f);

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

		//arrows and corresponding codes 
		if(Input.GetKey(KeyCode.RightArrow))
		{
			transform.position += rightmove * Time.deltaTime;
		}

		if(Input.GetKey(KeyCode.LeftArrow))
		{
			transform.position += leftmove * Time.deltaTime;
		}
		
		if(Input.GetKey(KeyCode.DownArrow))
		{
			transform.position += downmove * Time.deltaTime;
		}
		
		if(Input.GetKey(KeyCode.UpArrow))
		{
			transform.position += upmove * Time.deltaTime;
		}


		//create ray and raycast objects for use in jumping
		Ray sensor = new Ray(transform.position, Vector3.down);
		RaycastHit rayHit = new RaycastHit();

		//jump but only on ground
		if (Input.GetKeyDown(KeyCode.Space) && Physics.Raycast(sensor, out rayHit, 1f))
		{
			//transform.position += jump * Time.deltaTime;
			rigidbody.AddForce(jump, ForceMode.VelocityChange);
		}
	}
}