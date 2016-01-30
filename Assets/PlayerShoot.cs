using UnityEngine;
using System.Collections;

public class PlayerShoot : MonoBehaviour {

	[HideInInspector] public float m_angleToMouse = 0.0f;
	public Camera m_camera;
	public Transform projectile;
	public float shotSpeed;
	public Ability activeAbility;

	void Start(){
		activeAbility = this.GetComponent<WaterBolt>();
	}

	// Update is called once per frame
	void Update () {

		Ray mouseRay = m_camera.ScreenPointToRay(Input.mousePosition);
		Plane floor = new Plane(Vector3.up, 0.0f);
		
		float dist;
		
		if (floor.Raycast(mouseRay, out dist))
		{
			Vector3 point = mouseRay.GetPoint(dist);
			m_angleToMouse = -Mathf.Atan2(point.z-transform.position.z, point.x-transform.position.x)*Mathf.Rad2Deg;
		}

		if(Input.GetKeyDown(KeyCode.Space) && activeAbility.canShoot())
			shoot();
		
	}

	void shoot(){

		//Create Shot
		Vector3 projectilePosition = this.transform.position;
		projectilePosition += this.transform.right * 1.5f;
		Transform clone = Instantiate(projectile, projectilePosition, Quaternion.identity) as Transform;
		activeAbility.setShot(clone.GetComponent<Projectile>());
		clone.RotateAround(this.transform.position, Vector3.up, m_angleToMouse);

		//Shot Pattern
		Matrix4x4 rotMatrix = new Matrix4x4();
		rotMatrix.SetTRS(new Vector3(), Quaternion.Euler(0.0f, m_angleToMouse, 0.0f), new Vector3(1.0f, 1.0f, 1.0f));
		clone.GetComponent<Rigidbody>().velocity = rotMatrix.MultiplyVector(Vector3.right);
		clone.GetComponent<Rigidbody>().velocity *= shotSpeed; 
		 
	}
}
