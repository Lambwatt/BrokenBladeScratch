using UnityEngine;
using System.Collections;

public class PlayerPointToMouse : MonoBehaviour {
	
	[HideInInspector] public float m_angleToMouse = 0.0f;
	public Camera m_camera;
	// Update is called once per frame
	void Update () {

		Ray mouseRay = m_camera.ScreenPointToRay(Input.mousePosition);
		Plane floor = new Plane(Vector3.up, 0.0f);

		float dist;

		if (floor.Raycast(mouseRay, out dist))
		{
			Vector3 point = mouseRay.GetPoint(dist);
			m_angleToMouse = Mathf.Atan2(point.z-transform.position.z, point.x-transform.position.x)*Mathf.Rad2Deg;
			Debug.Log (m_angleToMouse);
		}


	}


}
