using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {

	public Vector3 direction;
	public float speed = 0;

	// Update is called once per frame
	void Update () {
		transform.position += direction*speed*Time.deltaTime;
	}


}
