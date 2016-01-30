using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {
	
	private CollisionResponse collisionResponse = new BasicCollisionResponse();

	public delegate void Effect(Entity e);
	public Effect effect;


	// Update is called once per frame
	void OnCollisionEnter(Collision col) {
		if(collisionResponse!=null){
			if(collisionResponse.collided(col)){
				if(collisionResponse.isValidTarget(col)){
			    	effect(col.gameObject.GetComponent<Entity>());

				}
				Destroy(this.gameObject);
			}
		}
	}
}
