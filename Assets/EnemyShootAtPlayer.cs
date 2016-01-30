using UnityEngine;
using System.Collections;

public class EnemyShootAtPlayer : MonoBehaviour {
	
	Transform player;
	public float speed;
	public float firingInterval;
	float intervalRemaining;
	public Transform projectile;
	Ability attack;
	// Use this for initialization
	void Start () {
		attack = this.GetComponent<Spark>();
		Debug.Log(attack);
		player = GameObject.FindGameObjectWithTag("Player").transform;
	}
	
	// Update is called once per frame
	void Update () {
		if(intervalRemaining <= 0.0f){
			shoot ();
			intervalRemaining = Random.value*firingInterval + firingInterval;
		}else{
			intervalRemaining-=Time.deltaTime;
		}
	}

	void shoot(){
		if(player!=null){
			float angleToPlayer = -Mathf.Atan2(player.position.z-transform.position.z, player.position.x-transform.position.x)*Mathf.Rad2Deg;
			
			Vector3 projectilePosition = this.transform.position;
			projectilePosition += this.transform.right * 1.5f;

			Transform clone = Instantiate(projectile, projectilePosition, Quaternion.identity) as Transform;

			attack.setShot(clone.GetComponent<Projectile>());
			clone.RotateAround(this.transform.position, Vector3.up, angleToPlayer);
			
			Matrix4x4 rotMatrix = new Matrix4x4();
			rotMatrix.SetTRS(new Vector3(), Quaternion.Euler(0.0f, angleToPlayer, 0.0f), new Vector3(1.0f, 1.0f, 1.0f));
			clone.GetComponent<Rigidbody>().velocity = rotMatrix.MultiplyVector(Vector3.right);
			clone.GetComponent<Rigidbody>().velocity *= speed; 
		}
	}
}
