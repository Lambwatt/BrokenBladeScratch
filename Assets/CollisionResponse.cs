using UnityEngine;
using System.Collections;

public interface CollisionResponse {

	bool collided(Collision col);
	bool isValidTarget(Collision col);

}
