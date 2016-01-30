using UnityEngine;
using System.Collections;

public class EnemyMoveRandom : MonoBehaviour {
	
	public float m_speed;
	private float m_time = 0;
	private Rigidbody body;

	void Start(){
		body = this.GetComponent<Rigidbody>();
	}

	// Update is called once per frame
	void Update () {

		if(m_time<= 0){
			float angle = Random.value*360.0f;
			m_time = (Random.value*3.0f)+2.0f;
			Matrix4x4 rotMatrix = new Matrix4x4();
			rotMatrix.SetTRS(new Vector3(), Quaternion.Euler(0.0f, angle, 0.0f), new Vector3(1.0f, 1.0f, 1.0f));
			body.velocity = rotMatrix.MultiplyVector(Vector3.right);
			body.velocity *= m_speed; 
		}else{
			m_time-=Time.deltaTime;
		}
	}
}
