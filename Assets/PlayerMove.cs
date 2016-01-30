using UnityEngine;
using System.Collections;

public class PlayerMove : MonoBehaviour {

	public float speed;

	// Update is called once per frame
	void Update () {

		Vector3 step = new Vector3(0.0f, 0.0f, 0.0f);

		if(Input.GetKey(KeyCode.W))
			step.z+=speed*Time.deltaTime;
		if(Input.GetKey(KeyCode.S))
			step.z-=speed*Time.deltaTime;
		if(Input.GetKey(KeyCode.D))
			step.x+=speed*Time.deltaTime;
		if(Input.GetKey(KeyCode.A))
			step.x-=speed*Time.deltaTime;

		transform.position+=step;
	}
}
