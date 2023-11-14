using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
	public float MovementSpeed = 1;
	public float RotationSpeed = 2;

	// ReSharper disable UnusedMember.Local
	private void Update()
	// ReSharper restore UnusedMember.Local
	{
		var rmbPressed = Input.GetMouseButton(1);
		Screen.lockCursor = rmbPressed;
		Cursor.visible = !rmbPressed;
		GetComponent<Camera>().nearClipPlane += Input.GetAxis("Mouse ScrollWheel") * Time.deltaTime * 2;
		if (rmbPressed)
		{
			transform.Rotate(Vector3.up, Input.GetAxis("Mouse X") * Time.deltaTime * RotationSpeed, Space.World);
			transform.Rotate(Vector3.right, -Input.GetAxis("Mouse Y") * Time.deltaTime * RotationSpeed, Space.Self);
			var movementDelta = Vector3.zero;
			if (Input.GetKey(KeyCode.W))
				movementDelta = transform.forward;
			if (Input.GetKey(KeyCode.S))
				movementDelta -= transform.forward;
			if (Input.GetKey(KeyCode.A))
				movementDelta -= transform.right;
			if (Input.GetKey(KeyCode.D))
				movementDelta += transform.right;
			if (Input.GetKey(KeyCode.E))
				movementDelta += transform.up;
			if (Input.GetKey(KeyCode.Q))
				movementDelta -= transform.up;
			var speed = Input.GetKey(KeyCode.LeftShift) ? 3 * MovementSpeed : MovementSpeed;
			transform.position += movementDelta.normalized * Time.deltaTime * speed;
		}
	}

	// ReSharper disable UnusedMember.Local
	private void OnGUI()
	// ReSharper restore UnusedMember.Local
	{
		GUI.Label(new Rect(5, 5, 300, 100), 
			"Controls:\n  Right mouse button: control camera\n  W,S,A,D,E,Q keys: move camera\n  Left Shift: triple camera speed");
	}
}
