using UnityEngine;

// 쉐이더 확인용
public class ObjectMove : MonoBehaviour {
	
	public bool isRotate = false;
	public bool isMove = false;

	public float rotateSpeed = 30f;
	public Vector3 rotateAxis = Vector3.right;

	public float moveSpeed = 2f;
	public float distance = 0.8f;

	private Vector3 spawnPoint;


	private void Start() {
		spawnPoint = transform.position;
	}

	private void Update() {
		if (isRotate) {
			transform.Rotate(rotateAxis, rotateSpeed * Time.deltaTime);
		}

		if (isMove) {
			float sinValue = Mathf.Sin(Time.time * moveSpeed);
			transform.position = spawnPoint + (transform.right * sinValue * distance);
		}
	}
}
