using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {
	
	public CollisionResponse collisionResponse = new BasicCollisionResponse();

	// Update is called once per frame
	void OnCollisionEnter(Collision col) {
		Debug.Log ("Collision happened");
		if(collisionResponse!=null){
			if(collisionResponse.handleCollision(col)){
				Destroy(this.gameObject);
			}
		}
	}
	
}
