using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {

    [SerializeField]
    [Tooltip("The movement speed of the player.")]
    [Range(1, 100)]
    private float moveSpeed = 25.0f;

    // The direction of the projectile
    private Vector3 direction;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Fire2") > 0)
        {
            float distance = gameObject.transform.position.z - Camera.main.transform.position.z;
            direction = new Vector3(Input.mousePosition.x, Input.mousePosition.y, distance);
            direction = Camera.main.ScreenToWorldPoint(direction);
        }
        if (Mathf.Abs((gameObject.transform.position - direction).magnitude) >= .5f)
        {
            transform.position = Vector3.MoveTowards(transform.position, direction, moveSpeed * Time.deltaTime);
        }
    }
}
