using UnityEngine;
using System.Collections;

public class BasicCollisionResponse: CollisionResponse {

	public bool handleCollision(Collision col){
		return true;
	}

}
