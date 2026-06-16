using UnityEngine;

public class ObjectMove : MonoBehaviour {

	public bool isRotate = false;
	public bool isMove = false;

	public float rotateSpeed = 30f;

	public float moveSpeed = 2f;
	public float distance = 0.8f;

	private Vector3 spawnPoint;


	private void Start() {
		spawnPoint = transform.position;
	}

	private void Update() {
		if (isRotate) {
			transform.Rotate(0, 0, rotateSpeed * Time.deltaTime);
		}

		if (isMove) {
			float sinValue = Mathf.Sin(Time.time * moveSpeed);
			transform.position = spawnPoint + (transform.right * sinValue * distance);
		}
	}
}
