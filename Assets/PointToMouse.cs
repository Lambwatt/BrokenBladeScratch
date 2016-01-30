using UnityEngine;
using System.Collections;

public class PointToMouse : MonoBehaviour {

	// Update is called once per frame
	void Update () {
		transform.position = transform.parent.position + new Vector3(1.0f, 0.0f, 0.0f);
		transform.rotation = new Quaternion(0.0f, 0.0f, 0.0f, 0.0f);
		transform.RotateAround(Vector3.forward, 90.0f*Mathf.Deg2Rad);
		transform.RotateAround(transform.parent.position, Vector3.up, -GetComponentInParent<PlayerPointToMouse>().m_angleToMouse);
	}
}
