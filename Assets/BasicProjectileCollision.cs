using UnityEngine;
using System.Collections;

public class BasicCollisionResponse: CollisionResponse {

	public bool collided(Collision col){
		return col.gameObject.CompareTag("Enemy") || col.gameObject.CompareTag("Player") || col.gameObject.CompareTag("Wall");
	}

	public bool isValidTarget(Collision col){
		if(col.gameObject.CompareTag("Enemy") || col.gameObject.CompareTag("Player")){
			return true;
		}

		return false;
		

	}

}
